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
    public class ValidateUserInputsTests
    {
        private readonly ValidateUserInputs _validateUserInputs;

        public ValidateUserInputsTests()
        {
            _validateUserInputs = new ValidateUserInputs();
        }

        [TestMethod()]
        public void ValidateUserInputLengthTestSuccess()
        {
            var result = _validateUserInputs.ValidateUserInputLength("4", out int len);

            Assert.IsTrue(result);
            Assert.AreEqual(len, 4);
        }

        [TestMethod()]
        public void ValidateUserInputLengthTestFail()
        {
            var result = _validateUserInputs.ValidateUserInputLength("a", out int len);
            var result1 = _validateUserInputs.ValidateUserInputLength("7", out int len1);
            var result2 = _validateUserInputs.ValidateUserInputLength("-7", out int len2);

            Assert.IsFalse(result);
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod()]
        public void ValidateUserInputTypeTestSuccess()
        {
            var result = _validateUserInputs.ValidateUserInputType("H");
            var result1 = _validateUserInputs.ValidateUserInputType("V");

            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [TestMethod()]
        public void ValidateUserInputTypeTestFail()
        {
            var result = _validateUserInputs.ValidateUserInputType("a");
            var result1 = _validateUserInputs.ValidateUserInputType("2");

            Assert.IsFalse(result);
            Assert.IsFalse(result1);
        }

        [TestMethod()]
        public void ValidatePlacementInputTestSuccess()
        {
            var result = _validateUserInputs.ValidatePlacementInput("B1");
            var result1 = _validateUserInputs.ValidatePlacementInput("H7");

            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [TestMethod()]
        public void ValidatePlacementInputTestFail()
        {
            var result = _validateUserInputs.ValidatePlacementInput("B16");
            var result1 = _validateUserInputs.ValidatePlacementInput("Q4");

            Assert.IsFalse(result);
            Assert.IsFalse(result1);
        }

        [TestMethod()]
        public void ValidatePlacementTestSuccess()
        {
            var result = _validateUserInputs.ValidatePlacement("B2", 'V', 5);
            var result1 = _validateUserInputs.ValidatePlacement("J6", 'H', 4);

            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [TestMethod()]
        public void ValidatePlacementTestFail()
        {
            var result = _validateUserInputs.ValidatePlacement("I9", 'V', 3);
            var result1 = _validateUserInputs.ValidatePlacement("G8", 'H', 5);

            Assert.IsFalse(result);
            Assert.IsFalse(result1);

            result = _validateUserInputs.ValidatePlacement("A19", 'V', 3);

            Assert.IsFalse(result);
        }
    }
}