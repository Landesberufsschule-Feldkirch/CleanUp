using CommunityToolkit.Mvvm.Input;

namespace CleanUp.ViewModel;

public partial class VmCleanUp
{

    [RelayCommand]
    private void Start()
    {
        _mainWindow.TextBox.Clear();
        _mainWindow.ModelCleanUp.OrdnerLoeschen();
    }

    [RelayCommand]
    private void Ordner()
    {
        using var dialog = new System.Windows.Forms.FolderBrowserDialog();
        if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

        var ordnerTypen = _mainWindow.CbOrdnerTypen.SelectionBoxItem.ToString();
        _mainWindow.ModelCleanUp.PfadAktualisieren(dialog.SelectedPath, ordnerTypen);
    }
}