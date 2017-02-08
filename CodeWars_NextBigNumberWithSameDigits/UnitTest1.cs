using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        [TestMethod]
        public void NextBiggerNumber_Give_12_Return_21()
        {
            //Assign
            int input = 12;
            int expected = 21;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        private int NextBiggerNumber(int input)
        {
            List<char> digits = new List<char>();

            foreach (char digit in input.ToString())
            {
                digits.Add(digit);
            }

            if (digits.Count > 1 && digits[0] < digits[1])
            {
                char temp = digits[0];
                digits[0] = digits[1];
                digits[1] = temp;
                string result = new string(digits.ToArray());
                return int.Parse(result);
            }
            else
                return -1;
        }
    }
}