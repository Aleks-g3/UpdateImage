using System.ComponentModel;

namespace UserControlPanel.Model
{
    public class Process : INotifyPropertyChanged
    {
        private string imageFile;

        public string ImageFile
        {
            get
            {
                return imageFile;
            }
            set
            {
                if (imageFile != value)
                {
                    imageFile = value;
                    RaisePropertyChanged("ImageFile");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
