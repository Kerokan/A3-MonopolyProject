using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ushort[] Expected = new ushort[] { 1, 1 };
            Random rand = new Random();
            ushort[] result = new ushort[] { (ushort)rand.Next(1, 2), (ushort)rand.Next(1, 2) };
            Assert.Equals(Expected, result);
        }
    }
}
