using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suparas4192DevOps;

namespace Suparas4192DevOps.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void AddTest()
        {
            int x = 1;
            int y = 2;
            int expected = 3;
            int actual = Program.Add(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}
