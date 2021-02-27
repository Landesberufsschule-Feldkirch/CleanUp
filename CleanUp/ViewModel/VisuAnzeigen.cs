using System.ComponentModel;

namespace CleanUp.ViewModel
{
    public class VisuAnzeigen : INotifyPropertyChanged
    {
        public VisuAnzeigen()
        {
            EnableButton = false;
            TextBoxText = "";
        }

        #region EnableButton
        private bool _enableButton;
        public bool EnableButton
        {
            get => _enableButton;
            set
            {
                _enableButton = value;
                OnPropertyChanged(nameof(EnableButton));
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
                OnPropertyChanged(nameof(TextBoxText));
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