using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void NextBiggerNumber_Give_30_Return_NoBiggerNumber()
        {
            //Assign
            int input = 30;
            int expected = NoBiggerNumber;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_22_Return_NoBiggerNumber()
        {
            //Assign
            int input = 22;
            int expected = NoBiggerNumber;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_513_Return_531()
        {
            //Assign
            int input = 513;
            int expected = 531;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_153_Return_315()
        {
            //Assign
            int input = 153;
            int expected = 315;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_531__Return_NoBiggerNumber()
        {
            //Assign
            int input = 531;
            int expected = NoBiggerNumber;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_111_Return_NoBiggerNumber()
        {
            //Assign
            int input = 111;
            int expected = NoBiggerNumber;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NextBiggerNumber_Give_2017_Return_2071()
        {
            //Assign
            int input = 2017;
            int expected = 2071;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void NextBiggerNumber_Give_1072_Return_1207()
        {
            //Assign
            int input = 1072;
            int expected = 1027;
            //Act
            int actual = NextBiggerNumber(input);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        private int NextBiggerNumber(int input)
        {
            if (HasNextBiggerNumber(input))
            {
                return GetNextBiggerNumber(input);
            }
            else
                return NoBiggerNumber;
        }

        private  int GetNextBiggerNumber(int input)
        {
            List<char> digits = input.ToString().ToList<char>();
            int highestDigit = 0;
            int lowestDigit = digits.Count - 1;

            bool swapped = false;
            int previousIndex = lowestDigit - 1;
            int index = lowestDigit;

            while(previousIndex > highestDigit)
            {
                if (digits[index] > digits[previousIndex])
                {
                    digits.swap(index, previousIndex);
                    swapped = true;
                    break;
                }
                index--;
                previousIndex = index - 1;
            }            
       
            List<char> resultChars = digits;
            // example:  1432 -> 2431 -> 2134
            if (!swapped)
            {
                digits.swap(highestDigit, lowestDigit);
                resultChars = digits.KeepHighestDigitAndOrderRestDigitsByAscending();
            }

            int result = int.Parse( new string(resultChars.ToArray()));
            return result;
        }

        private bool HasNextBiggerNumber(int input)
        {
            List<char> digits = new List<char>();
            HashSet<char> charsTableOfInput = new HashSet<char>();

            foreach (char digit in input.ToString())
            {
                digits.Add(digit);

                if (!charsTableOfInput.Contains(digit))
                {
                    charsTableOfInput.Add(digit);
                }
            }

            //Only one digit like "1" or "9"
            if (digits.Count == 1)
            {
                return false;
            }
            //all digits with same character like "111", "2222"
            else if (charsTableOfInput.Count == 1)
            {
                return false;
            }
            // check all digits are ordered by descending like "54321" has no bigger number , "54231" has bigger
            else
            {
                var digitsOrderByDescent = digits.OrderByDescending(digit => digit).ToList();

                return !digits.SequenceEqual(digitsOrderByDescent);
            }
        }
    }

    public static class MyExtensions
    {
        public static void swap(this List<char> digits, int index1, int index2)
        {
            char temp = digits[index2];
            digits[index2] = digits[index1];
            digits[index1] = temp;
        }

        public static List<char> KeepHighestDigitAndOrderRestDigitsByAscending(this List<char> digits)
        {
            var restDigitsOrderByAscend = digits.Where((p, index) => index != 0).OrderBy(digit => digit).ToList();

            List<char> resultDigits = new List<char>();
            resultDigits.Add(digits[0]);

            foreach (var digit in restDigitsOrderByAscend)
            {
                resultDigits.Add(digit);
            }

            return resultDigits;
        }
    }
}