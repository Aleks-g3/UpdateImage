using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpdateImage;

namespace UpdateImageTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = @"D:\IMG_2438_Processed.jpg";
        private string result;

        [TestMethod]
        public void ToMainColors_withPathAndImageFile_expected_D_IMG_2438_Processed_jpg()
        {

            ImageProcessing imageProcessing = new ImageProcessing();
             result = imageProcessing.ToMainColors(@"D:\", "IMG_2438.jpg");
            

            Assert.AreEqual(Expected, result);
        }
        [TestMethod]
        public void ToMainColorsAsync_withPathAndImageFile_expected_D_IMG_2438_Processed_jpg()
        {
            
            ImageProcessing imageProcessing = new ImageProcessing();
            result = Task.Run(async () => await imageProcessing.ToMainColorsAsync(@"D:\", "IMG_2438.jpg")).Result;
            Assert.AreEqual(Expected, result);
        }

    }
}
