using Microsoft.Win32;
using System.IO;
using System.Windows;
using UserControlPanel.ViewModel;

namespace UserControlPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        ProcessViewModel viewModel = new ProcessViewModel();

        public MainWindow()
        {

            InitializeComponent();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp";
        }

        private void btnConvertImage_Click(object sender, RoutedEventArgs e)
        {
            lblWait.Visibility = Visibility.Visible;
            if (openFileDialog.ShowDialog() == true)
            {

                viewModel.LoadImage(Path.GetDirectoryName(openFileDialog.FileName), openFileDialog.SafeFileName);

            }
            if (!string.IsNullOrWhiteSpace(viewModel.ImageFile))
            {
                DisableButtons();
            }
            lblWait.Visibility = Visibility.Hidden;
        }

        private void btnConvertImageAsync_Click(object sender, RoutedEventArgs e)
        {
            lblWait.Visibility = Visibility.Visible;
            if (openFileDialog.ShowDialog() == true)
            {

                viewModel.LoadImageAsync(Path.GetDirectoryName(openFileDialog.FileName), openFileDialog.SafeFileName);
            }
            if (!string.IsNullOrWhiteSpace(viewModel.ImageFile))
            {
                DisableButtons();
            }
            lblWait.Visibility = Visibility.Hidden;
        }

        private void DisableButtons()
        {
            this.DataContext = viewModel;
            btnConvertImage.IsEnabled = false;
            btnConvertImageAsync.IsEnabled = false;
        }
    }
}
