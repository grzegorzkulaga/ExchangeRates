using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    
    public static class CurrencyConverterOperations
    {
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
