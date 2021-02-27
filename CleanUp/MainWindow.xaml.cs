using System.Windows;

namespace CleanUp
{
    public partial class MainWindow
    {
        private readonly ViewModel.ViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = new ViewModel.ViewModel();
            InitializeComponent();
            DataContext = _viewModel;

            CbOrdnerTypen.Items.Add("Bitte auswählen");
            CbOrdnerTypen.Items.Add("bin + obj");
            CbOrdnerTypen.Items.Add("bin");
            CbOrdnerTypen.Items.Add("obj");
        }
        internal void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            using var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            var ordnerTypen = CbOrdnerTypen.SelectionBoxItem.ToString();
            _viewModel.CleanUp.PfadAktualisieren(dialog.SelectedPath, ordnerTypen);
        }
    }
}