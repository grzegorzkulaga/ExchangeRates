using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ExchangeRates;
using ExchangeRates.Forms;

namespace ExchangeRates.Tests
{
    [TestFixture()]
    public class ExchangeRatesTest
    {
        [Test()]
        [TestCase(14, 5, 44, "1,59")]
        [TestCase(0, 0, 4, "0")]
        [TestCase(100, 0, 0, "0")]
        [TestCase(0, 3, -4, "0")]
        [TestCase(-20, 4, 3, "-26,67")]
        [TestCase(1.2, -5, 20, "-0,3")]
        [TestCase(-0, 4, 1.2, "0")]
        [TestCase(null, 4, 30, "0")]
        [TestCase(0.001, 2.1, 1, "0")]
        public void ConvertCurrenciesTest(double amount, double firstRate, double secondRate, string res)
        {

            string result = Math.Round(CurrencyConverterOperations.ConvertCurrencies(amount, firstRate, secondRate),2).ToString();
            Assert.AreEqual(res, result);
        }



    }
}
