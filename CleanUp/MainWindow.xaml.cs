using CleanUp.ViewModel;

namespace CleanUp;

public partial class MainWindow
{
    public VmCleanUp ViewModel { get; set; }
    public Model.CleanUp ModelCleanUp { get; set; }

    public MainWindow()
    {
        ViewModel = new VmCleanUp(this);
        ModelCleanUp = new Model.CleanUp(ViewModel);

        InitializeComponent();
        DataContext = ViewModel;

        CbOrdnerTypen.Items.Add("Bitte auswählen");
        CbOrdnerTypen.Items.Add("bin + obj");
        CbOrdnerTypen.Items.Add("bin");
        CbOrdnerTypen.Items.Add("obj");
        CbOrdnerTypen.Items.Add("net5");
        CbOrdnerTypen.Items.Add("net6");
    }
}