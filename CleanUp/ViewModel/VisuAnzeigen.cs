using System.ComponentModel;
using System.Threading;

namespace CleanUp.ViewModel
{
    public class VisuAnzeigen : INotifyPropertyChanged
    {
        private readonly CleanUp.Model.CleanUp _cleanUp;

        public VisuAnzeigen(CleanUp.Model.CleanUp cleanUp)
        {
            _cleanUp=cleanUp;

            EnableButton = false;
            TextBoxText = "";

            System.Threading.Tasks.Task.Run(VisuAnzeigenTask);

        }
        private void VisuAnzeigenTask()
        {
            while (true)
            {
                TextBoxText = _cleanUp.TextBoxText();
                EnableButton = _cleanUp.ButtonEnabled();
                Thread.Sleep(10);
            }
            // ReSharper disable once FunctionNeverReturns
        }
        
        #region EnableButton
        private bool _enableButton;
        public bool EnableButton
        {
            get => _enableButton;
            set
            {
                _enableButton = value;
                OnPropertyChanged("EnableButton");
            }
        }
        #endregion

        #region TextBoxText
        private object _textBoxText;
        public object TextBoxText
        {
            get => _textBoxText;
            set
            {
                _textBoxText = value;
                OnPropertyChanged("TextBoxText");
            }
        }
        #endregion
        
        #region iNotifyPeropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion iNotifyPeropertyChanged Members
    }
}