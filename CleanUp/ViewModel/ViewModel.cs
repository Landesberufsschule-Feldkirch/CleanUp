using CleanUp.Commands;
using System.Windows.Input;

namespace CleanUp.ViewModel
{
    public class ViewModel
    {
        // ReSharper disable once UnusedMember.Global
        public Model.CleanUp CleanUp { get; }
        public VisuAnzeigen ViAnzeige { get; set; }
        public ViewModel()
        {
            CleanUp = new Model.CleanUp();
            ViAnzeige = new VisuAnzeigen(CleanUp);
        }

        private ICommand _btnStart;
        // ReSharper disable once UnusedMember.Global
        public ICommand BtnStart => _btnStart ??= new RelayCommand(_ => CleanUp.TasterStart(), _ => true);
    }
}
