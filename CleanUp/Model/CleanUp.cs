using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using CleanUp.ViewModel;

namespace CleanUp.Model;

public class CleanUp
{
    public ObservableCollection<string> Einstellungen { get; set; }
    private readonly StringBuilder _textBoxText;
    private readonly List<string> _ordnerListe;
    private readonly VmCleanUp _vmCleanUp;
    public CleanUp(VmCleanUp vmCleanUp)
    {
        _vmCleanUp = vmCleanUp;

        _ordnerListe = new List<string>();
        _textBoxText = new StringBuilder();
        Einstellungen = new ObservableCollection<string>();
        Einstellungen.Insert(0, "Bitte Auswählen");
        Einstellungen.Insert(1, "/bin");
        Einstellungen.Insert(2, "/obj");
        Einstellungen.Insert(3, "/net5");
        Einstellungen.Insert(4, "/net6");
    }
    public void OrdnerLoeschen()
    {
        _vmCleanUp.StringTextBoxText = "";
        foreach (var ergebnis in _ordnerListe.Select(DateienUndOrdner.OrdnerLoeschen))
        {
            _textBoxText.Append($"{ergebnis}");
            _vmCleanUp.StringTextBoxText = _textBoxText.ToString();
            //  Application.Current.Dispatcher.Invoke(() => { _vmCleanUp.StringTextBoxText = _textBoxText.ToString(); });
        }
    }
    internal void PfadAktualisieren(string selectedPath, string ordnerTypen)
    {
        var folderNames = Directory.GetDirectories(selectedPath, "*.*", SearchOption.AllDirectories);

        _textBoxText.Clear();
        _ordnerListe.Clear();

        foreach (var folderName in folderNames)
        {
            if (folderName.Contains(".git")) continue;

            if (ordnerTypen == "bin + obj")
            {
                if (!folderName.Contains("bin") && !folderName.Contains("obj")) continue;

                _ordnerListe.Add(folderName);
                _textBoxText.Append($"{folderName}\n");
            }
            else
            {
                if (!folderName.Contains(ordnerTypen)) continue;

                _ordnerListe.Add(folderName);
                _textBoxText.Append($"{folderName}\n");
            }
        }

        _vmCleanUp.StringTextBoxText = _textBoxText.ToString();
        _vmCleanUp.BoolEnableButton = true;
    }
}