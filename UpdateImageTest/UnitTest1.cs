using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UpdateImage;

namespace UpdateImageTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string Expected = "test.png";
        [TestMethod]
        public void TestMethod1()
        {

            ImageProcessing imageProcessing = new ImageProcessing();
            string result = imageProcessing.ToMainColors(@"D:\IMG_2438.jpg");

            Assert.AreEqual(Expected, result);
        }
        [TestMethod]
        public async void TestMethod2()
        {

            ImageProcessing imageProcessing = new ImageProcessing();
            string result = await imageProcessing.ToMainColorsAsync(@"D:\IMG_2438.jpg");

            Assert.AreEqual(Expected, result);
        }

    }
}
