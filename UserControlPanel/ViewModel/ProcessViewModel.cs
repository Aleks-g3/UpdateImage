using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Process Process
        {
            get;
            set;
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
