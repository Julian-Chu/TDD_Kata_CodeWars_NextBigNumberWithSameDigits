using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeWars_NextBigNumberWithSameDigits
{
    [TestClass]
    public class UnitTest1
    {
        private const int NoBiggerNumber = -1;

        [TestMethod]
        public void NextBiggerNumber_Give_1_Return_NoBiggerNumber()
        {
            //Assign
            int input = 1;
            int expected = NoBiggerNumber;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_9_Return_NoBiggerNumber()
        {
            //Assign
            int input = 9;
            int expected = NoBiggerNumber;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }


        private int NextBiggerNumber(int v)
        {
            return -1;
        }
    }
}