using System.Drawing;
using System.Threading.Tasks;

namespace UpdateImage
{
    public class ImageProcessing
    {
        private Process process;

        public ImageProcessing()
        {
            process = new Process();
        }
        public string ToMainColors(string path,string imageFile)
        {
            return process.readAndModify(path,imageFile);
        }
        public async Task<string> ToMainColorsAsync(string path,string imageFile)
        {
            return await Task.Run(() =>  process.readAndModify(path,imageFile));
        }
    }
}
