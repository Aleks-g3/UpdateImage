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
        public string Time
        {
            get
            {
                return process.Time;
            }
        }

        public void LoadImage(string imagePath)
        {
            timer.Restart();
            timer.Start();
            process.ImageFile = imageProcessing.ToMainColors(imagePath);
            timer.Stop();
            timeTaken = timer.Elapsed;
            process.Time=timeTaken.ToString(@"m\:ss\.fff");
        }

        public void LoadImageAsync(string imagePath)
        {
            timer.Restart();
            timer.Start();
            process.ImageFile = Task.Run(async () => await imageProcessing.ToMainColorsAsync(imagePath)).Result;
            timer.Stop();
            timeTaken = timer.Elapsed;
            process.Time= timeTaken.ToString(@"m\:ss\.fff");
        }
    }
}
