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
        public string ToMainColors(string imageFile)
        {
            return process.readAndModify(imageFile);
        }
        public async Task<string> ToMainColorsAsync(string imageFile)
        {
            return await Task.Run(() =>  process.readAndModify(imageFile));
        }
    }
}
