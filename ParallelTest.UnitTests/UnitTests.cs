using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParallelTest.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void NumberOfPrimesValid()
        {
            int numPrimes = Program.FindPrimesTasks(1000);

            Assert.AreEqual(168, numPrimes);
        }
    }
}
