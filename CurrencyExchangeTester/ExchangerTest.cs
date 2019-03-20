using System;
using System.Collections.Generic;
using CurrencyExchange;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CurrencyExchangeTester
{
    [TestClass]
    public class ExchangerTest
    {
        [TestMethod]
        public void TestExchangeSuccess()
        {
            double[] ammount =
            {
                1,
                50,
                100
            };

            List<Exchanger> testData = new List<Exchanger>();
            testData.Add(new Exchanger("EUR", 754.94));
            testData.Add(new Exchanger("USD", 663.11));
            testData.Add(new Exchanger("DKK", 100));
            testData.Add(new Exchanger("GBP", 852.85));
            testData.Add(new Exchanger("SEK", 76.1));
            testData.Add(new Exchanger("NOK", 78.4));
            testData.Add(new Exchanger("CHF", 683.58));
            testData.Add(new Exchanger("JPY", 5.9740));

            for (int i = 0; i < testData.Count; i ++)
            {
                for (int j = 0; j < testData.Count; j++)
                {
                    foreach(double value in ammount)
                    {
                        string[] request = { testData[i].Currency, testData[j].Currency};
                        double expected = (testData[i].ChangingCourseDKK / testData[j].ChangingCourseDKK) * value;
                        var actual = Exchange.ExchangeCurrencies(testData, request, value);

                        Assert.AreEqual(expected, actual);
                    }

                }
            }
        }
        public void TestExchangeError()
        {
            List<Exchanger> testData = new List<Exchanger>();
            testData.Add(new Exchanger("EUR", 754.94));
            testData.Add(new Exchanger("USD", 663.11));
            testData.Add(new Exchanger("DKK", 100));
            testData.Add(new Exchanger("GBP", 852.85));
            testData.Add(new Exchanger("SEK", 76.1));
            testData.Add(new Exchanger("NOK", 78.4));
            testData.Add(new Exchanger("CHF", 683.58));
            testData.Add(new Exchanger("JPY", 5.9740));

            double expected = -1;

            List<string[]> testDataInput = new List<string[]>();
            testDataInput.Add(new string[] { "ABC", "DEF" });
            testDataInput.Add(new string[] { "GHI", "JKL" });
            testDataInput.Add(new string[] { "MNO", "PQR" });
            testDataInput.Add(new string[] { "STU", "VWX" });
            testDataInput.Add(new string[] { "YZY", "ZYZ" });

            foreach(string[] test in testDataInput) { 
                var actual = Exchange.ExchangeCurrencies(testData, test, 1);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
