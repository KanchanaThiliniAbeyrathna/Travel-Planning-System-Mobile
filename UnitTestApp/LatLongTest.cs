using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using MyAppTrial.Models;

namespace UnitTestApp
{
    [TestClass]
    class LatLongTest
    {
        Place p = new Place();
        [TestMethod]
        public void ConvertTest()
        {
            Assert.Equals(4.144546878, p.covertToDouble("4.144546878"));
        }
    }
}
