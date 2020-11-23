using System.ComponentModel;

namespace UserControlPanel.Model
{
    public class Process : INotifyPropertyChanged
    {
        private string imageFile;

        private string time;

        public string ImageFile
        {
            get
            {
                return imageFile;
            }
            set
            {
                imageFile = value;
                RaisePropertyChanged("ImageFile");

            }
        }

        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                RaisePropertyChanged("Time");

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
