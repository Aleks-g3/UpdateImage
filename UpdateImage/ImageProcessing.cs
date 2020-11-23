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

        public string ToMainColors(string imagePath)
        {
            return process.ReadAndModify(imagePath);
        }

        public async Task<string> ToMainColorsAsync(string imagePath)
        {
            return await Task.Run(() => process.ReadAndModify(imagePath));
        }
    }
}
