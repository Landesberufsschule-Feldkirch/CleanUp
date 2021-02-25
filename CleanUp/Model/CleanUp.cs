using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CleanUp.Model
{
    public class CleanUp
    {
        public Einstellungen Einstellungen { get; set; }
        private bool _enableButton;
        private readonly StringBuilder _textBoxText;
        private readonly List<string> _ordnerListe;

        public CleanUp()
        {
            _ordnerListe = new List<string>();
            _textBoxText = new StringBuilder();
            Einstellungen = new Einstellungen();
            Einstellungen.AlleOrdnerBezeichnungen.Insert(0, new OrdnerNamen("Bitte Auswählen"));
            Einstellungen.AlleOrdnerBezeichnungen.Insert(0, new OrdnerNamen("/bin"));
            Einstellungen.AlleOrdnerBezeichnungen.Insert(0, new OrdnerNamen("/obj"));
        }
        private void OrdnerStrukturAnpassen()
        {
            _textBoxText.Clear();
            foreach (var ergebnis in _ordnerListe.Select(DateienUndOrdner.OrdnerLoeschen))
            {
                _textBoxText.Append($"{ergebnis}\n");
            }
        }
        internal void PfadAktualisieren(string selectedPath, string ordnerTypen)
        {
            _enableButton = true;
            var folderNames = Directory.GetDirectories(selectedPath, "*.*", SearchOption.AllDirectories);

            _textBoxText.Clear();
            _ordnerListe.Clear();

            foreach (var folderName in folderNames)
            {

                if (ordnerTypen == "bin + obj")
                {
                    if (folderName.Contains("bin") || folderName.Contains("obj"))
                    {
                        _ordnerListe.Add(folderName);
                        _textBoxText.Append($"{folderName}\n");
                    }
                }
                else
                {
                    if (!folderName.Contains(ordnerTypen)) continue;

                    _ordnerListe.Add(folderName);
                    _textBoxText.Append($"{folderName}\n");
                }

            }
        }
        internal object TextBoxText() => _textBoxText;
        internal void TasterStart() => System.Threading.Tasks.Task.Run(OrdnerStrukturAnpassen);
        public bool ButtonEnabled() => _enableButton;
    }
}