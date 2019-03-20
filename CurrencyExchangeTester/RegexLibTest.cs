using System;
using CurrencyExchange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyExchangeTester
{
    [TestClass]
    public class RegexLibTest
    {
        [TestMethod]
        public void TestIsCurrencyValidTrue()
        {

            bool expected = true;
            string[] testData =
            {
                "ABC/EFG",
                "HIJ/KLM",
                "NOP/QRS",
                "TUV/WXY",
                "ZUS/SEK",
                "AAA/BBB",
                "CCC/DDD"
            };

            foreach (string data in testData)
            {
                var actual = RegexLib.IsCurrencyValid(data);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestIsCurrencyValidFalse()
        {

            bool expected = false;
            string[] testData =
            {
                "ABC//EFG",
                "KEP/",
                "",
                " ",
                "   /   ",
                "ABCD/EFG",
                "BCD/WZYL",
                "abc/def",
                "EURDKK",
                "//////"
            };

            foreach (string data in testData)
            {
                var actual = RegexLib.IsCurrencyValid(data);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestIsNumberValidTrue()
        {

            bool expected = true;
            string[] testData =
            {
                "1.457896",
                "1000.541",
                "57",
                "0.57",
                "7.555555"
            };

            foreach (string data in testData)
            {
                var actual = RegexLib.IsNumberValid(data);
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void TestIsNumberValidFalse()
        {

            bool expected = false;
            string[] testData =
            {
                "1.457.896",
                "abc",
                "ABC",
                "A.B",
                "-10",
                "-1.45",
                ".14.15",
                "",
                " ",
                "."
            };

            foreach (string data in testData)
            {
                var actual = RegexLib.IsNumberValid(data);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
