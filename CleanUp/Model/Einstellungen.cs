using System.Collections.ObjectModel;

namespace CleanUp.Model
{
    public class Einstellungen
    {
        public ObservableCollection<OrdnerNamen> AlleOrdnerBezeichnungen { get; set; } = new();
    }

    public class OrdnerNamen
    {
        public OrdnerNamen(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
        }

        public string Bezeichnung { get; set; }
    }
}