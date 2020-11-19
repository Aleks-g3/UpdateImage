using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateImage
{
    public class ImageProcessing
    {
        private ImageProcessing() { }

        private static ImageProcessing imageProcessing;

        public static string readAndModificate(string imageFile)
        {
            try
            {
                if (imageProcessing == null)
                {
                    imageProcessing = new ImageProcessing();
                }
                Bitmap image = new Bitmap(imageFile);
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color colorPixel = image.GetPixel(x, y);
                        Color setColor= ToMainColors(colorPixel);
                        image.SetPixel(x, y, setColor);

                    }
                }
                string saveFile = "test.png";
                image.Save(saveFile);
                return saveFile;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(imageProcessing!=null)
                {
                    imageProcessing = null;
                }
            }
            return null;
        }
        public static Task<string> readAndModificateAsync(string imageFile)
        {
            try
            {
                if (imageProcessing == null)
                {
                    imageProcessing = new ImageProcessing();
                }
                Bitmap image = new Bitmap(imageFile);
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color colorPixel = image.GetPixel(x, y);
                        Color setColor = ToMainColors(colorPixel);
                        image.SetPixel(x, y, setColor);

                    }
                }
                string saveFile = "test.png";
                image.Save(saveFile);
                return Task.FromResult(saveFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (imageProcessing != null)
            {
                imageProcessing = null;
            }
            return null;
        }
        private static Color ToMainColors(Color color)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Color.FromArgb(0,0,0);
        }
        private static Task<Color> ToMainColorsAsync(Color color)
        {
            try
            {
                if (color.R > color.G && color.R > color.B)
                {
                    return Task.FromResult(Color.FromArgb(255, 0, 0));
                }
                else if (color.G > color.R && color.G > color.B)
                {
                    return Task.FromResult(Color.FromArgb(0, 255, 0));
                }

                return Task.FromResult(Color.FromArgb(0, 0, 255));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Task.FromResult(Color.FromArgb(0, 0, 0));
        }


    }
}
