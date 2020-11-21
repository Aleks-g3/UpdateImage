using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using UpdateImage;

namespace UpdateImageTest
{
    [TestClass]
    public class ImageProcessingTests
    {
        private string Expected = "Obraz 004_Processed.jpg";

        private string result;

        private ImageProcessing imageProcessing = new ImageProcessing();

        [TestMethod]
        public void ToMainColors_withPathAndImageFile_UpdateImage()
        {

            result = imageProcessing.ToMainColors("", "Obraz 004.jpg");
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ToMainColorsAsync_withPathAndImageFile_UpdateImage()
        {
            result = Task.Run(async () => await imageProcessing.ToMainColorsAsync("", "Obraz 004.jpg")).Result;
            Assert.AreEqual(Expected, result);
        }
    }
}
