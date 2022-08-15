using CommunityToolkit.Mvvm.ComponentModel;

namespace CleanUp.ViewModel;

public partial class VmCleanUp
{
    [ObservableProperty] private bool _boolEnableButton;

    [ObservableProperty] private string _stringTextBoxText;
}