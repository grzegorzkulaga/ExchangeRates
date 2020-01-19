using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    
    public static class CurrencyConverterOperations
    {/// <summary>
    /// Calculates and return proportion between two given rate values
    /// </summary>
    /// <param name="amount">amount of first Rate</param>
    /// <param name="firstRate"> Start rate</param>
    /// <param name="SecondRate"> Final rate</param>
    /// <returns></returns>
        public static double ConvertCurrencies(double amount, double firstRate, double SecondRate)
        {
            double result;
            if (SecondRate!=0)
            {
                result = (amount * firstRate) / SecondRate;
                return Math.Round(result,4);
            }
            else
            {
                return 0;
            }
          
        }
    }
}
