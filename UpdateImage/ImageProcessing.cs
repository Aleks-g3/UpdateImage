using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateImage
{
    public class ImageProcessing
    {
        private Process process;

        public ImageProcessing()
        {
            process = new Process();
        }
        public string ToMainColors(string imageFile)
        {
            try
            {
                return process.readAndModificate(imageFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public Task<string> ToMainColorsAsync(string imageFile)
        {
            try
            {
                return process.readAndModificateAsync(imageFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
