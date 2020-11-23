using System;
using System.Threading.Tasks;
using System.Windows;
using UpdateImage;
using UserControlPanel.Model;

namespace UserControlPanel.ViewModel
{
    public class ProcessViewModel
    {
        private ImageProcessing imageProcessing = new ImageProcessing();

        private Process process = new Process();

        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        private TimeSpan timeTaken;

        public string ImageFile
        {
            get
            {
                return process.ImageFile;
            }
        }

        public void LoadImage(string path, string imageFile)
        {
            timer.Restart();
            timer.Start();
            process.ImageFile = imageProcessing.ToMainColors(path, imageFile);
            timer.Stop();
            timeTaken = timer.Elapsed;
            MessageBox.Show("Czas wykonania : " + timeTaken.ToString(@"m\:ss\.fff"), "OK");
        }

        public void LoadImageAsync(string path, string imageFile)
        {
            timer.Restart();
            timer.Start();
            process.ImageFile = Task.Run(async () => await imageProcessing.ToMainColorsAsync(path, imageFile)).Result;
            timer.Stop();
            timeTaken = timer.Elapsed;
            MessageBox.Show("Czas wykonania : " + timeTaken.ToString(@"m\:ss\.fff"), "OK");
        }
    }
}
