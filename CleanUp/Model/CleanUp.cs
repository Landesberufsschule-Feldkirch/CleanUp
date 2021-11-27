using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace CleanUp.Model
{
    public class CleanUp
    {
        public ObservableCollection<string> Einstellungen { get; set; }
        private readonly StringBuilder _textBoxText;
        private readonly List<string> _ordnerListe;
        private readonly ViewModel.VisuAnzeigen _visuAnzeigen;

        public CleanUp(ViewModel.VisuAnzeigen viAnzeige)
        {
            _visuAnzeigen = viAnzeige;
            _ordnerListe = new List<string>();
            _textBoxText = new StringBuilder();
            Einstellungen = new ObservableCollection<string>();
            Einstellungen.Insert(0, "Bitte Auswählen");
            Einstellungen.Insert(1, "/bin");
            Einstellungen.Insert(2, "/obj");
            Einstellungen.Insert(3, "/net5");
            Einstellungen.Insert(4, "/net6");
        }
        private void OrdnerStrukturAnpassen()
        {
            _textBoxText.Clear();
            foreach (var ergebnis in _ordnerListe.Select(DateienUndOrdner.OrdnerLoeschen)) _textBoxText.Append($"{ergebnis}");
        }
        internal void PfadAktualisieren(string selectedPath, string ordnerTypen)
        {
            _visuAnzeigen.EnableButton = true;
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

            _visuAnzeigen.TextBoxText = _textBoxText;
        }
        internal void TasterStart() => System.Threading.Tasks.Task.Run(OrdnerStrukturAnpassen);
    }
}