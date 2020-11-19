using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateImage
{
    class Process : IProccess
    {
        public string readAndModificate(string imageFile)
        {

            Bitmap image = new Bitmap(imageFile);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color colorPixel = image.GetPixel(x, y);
                    Color setColor = chooseMainColor(colorPixel);
                    image.SetPixel(x, y, setColor);

                }
            }
            string saveFile = "test.png";
            image.Save(saveFile);
            return saveFile;
        }
        public Task<string> readAndModificateAsync(string imageFile)
        {
            return Task.Run<string>(() => { return readAndModificate(imageFile); });
        }
        private Color chooseMainColor(Color color)
        {

            if (color.R > color.G && color.R > color.B)
            {
                return Color.FromArgb(255, 0, 0);
            }
            else if (color.G > color.R && color.G > color.B)
            {
                return Color.FromArgb(0, 255, 0);
            }

            return Color.FromArgb(0, 0, 255);
        }



    }
}
