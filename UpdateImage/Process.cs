using System.Drawing;
using System.Text.RegularExpressions;

namespace UpdateImage
{
    class Process : IProccess
    {
        public string ReadAndModify(string path, string imageFile)
        {
            Bitmap image = new Bitmap(path + imageFile);
            Match match = Regex.Match(imageFile, @"([A-Za-z0-9\-_+/ ]+)\.(jpg|png|jpeg)$");
            string saveFile = path + match.Value.Replace(match.Groups[1].Value, match.Groups[1].Value + "_Processed");
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color colorPixel = image.GetPixel(x, y);
                    Color setColor = chooseMainColor(colorPixel);
                    image.SetPixel(x, y, setColor);
                }
            }
            image.Save(saveFile);
            return saveFile;
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
