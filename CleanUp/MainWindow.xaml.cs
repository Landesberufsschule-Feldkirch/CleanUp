using System.Windows;


namespace CleanUp
{
    public partial class MainWindow
    {
        public CleanUp.ViewModel.ViewModel ViewModel { get; set; }
        public MainWindow()
        {
            ViewModel = new ViewModel.ViewModel();
            InitializeComponent();
            DataContext = ViewModel;

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
            ViewModel.CleanUp.PfadAktualisieren(dialog.SelectedPath, ordnerTypen);
        }
    }
}