using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Business.Tests
{
    [TestClass()]
    public class GetCoordinatesTests
    {
        private readonly GetCoordinates _getCoordinates;

        public GetCoordinatesTests()
        {
            _getCoordinates = new GetCoordinates();
        }

        [TestMethod()]
        public void GetXYTestPass()
        {
            _getCoordinates.GetXY("J9", out int x, out int y);

            Assert.AreEqual(x, 10);
            Assert.AreEqual(y, 9);

            _getCoordinates.GetXY("BX", out x, out y);

            Assert.AreEqual(x, 2);
            Assert.AreEqual(y, 10);

            _getCoordinates.GetXY("D10", out x, out y);

            Assert.AreEqual(x, 4);
            Assert.AreEqual(y, 10);
        }

        [TestMethod()]
        public void GetXYTestFail()
        {
            var result = _getCoordinates.GetXY("Q10", out int x, out int y);

            Assert.IsFalse(result);

            result = _getCoordinates.GetXY("B0", out x, out y);

            Assert.IsFalse(result);

            result = _getCoordinates.GetXY("C15", out x, out y);

            Assert.IsFalse(result);

            result = _getCoordinates.GetXY("E1X", out x, out y);

            Assert.IsFalse(result);

            result = _getCoordinates.GetXY("Z1Q", out x, out y);

            Assert.IsFalse(result);
        }
    }
}