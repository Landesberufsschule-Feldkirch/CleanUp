using CommunityToolkit.Mvvm.ComponentModel;

namespace CleanUp.ViewModel;

public partial class VmCleanUp : ObservableObject
{
    private readonly MainWindow _mainWindow;

    public VmCleanUp(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;

        BoolEnableButton = false;
        StringTextBoxText = "";
    }
}