using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;
using UpdateImage;

namespace UpdateImageTest
{
    [TestClass]
    public class ImageProcessingTests
    {
        private string Expected = string.Format("{0}Resources\\Obraz 004_Processed.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));

        string fileName = string.Format("{0}Resources\\Obraz 004.jpg", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")));

        private string result;

        private ImageProcessing imageProcessing = new ImageProcessing();

        [TestMethod]
        public void ToMainColors_withPathAndImageFile_UpdateImage()
        {

            string t = fileName;
            result = imageProcessing.ToMainColors(fileName);
            Assert.AreEqual(Expected, result);
        }

        [TestMethod]
        public void ToMainColorsAsync_withPathAndImageFile_UpdateImage()
        {
            result = Task.Run(async () => await imageProcessing.ToMainColorsAsync(fileName)).Result;
            Assert.AreEqual(Expected, result);
        }
    }
}
