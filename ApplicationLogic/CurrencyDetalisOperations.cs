using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using System.Net;

namespace ExchangeRates
{
    public class CurrencyDetalisOperations
    {
        public currencyDetailsModel CurrencyDetails;
        public class DataObject
        {
            public string Name { get; set; }
        }
        /// <summary>
        /// asynchronous method which return details of specific currency. Data is taken from NBP API
        /// </summary>
        /// <param name="tablename">Name of one of three("A","B","C") tables which are given from NBP</param>
        /// <param name="currencyCode">Short currency name</param>
        /// <returns></returns>
        public async Task<currencyDetailsModel> getCurrencyDetails(string tablename,string currencyCode)
        {

            string url = $"http://api.nbp.pl/api/exchangerates/rates/"+tablename+"/"+currencyCode+"/last"+ "/10/?format=json";

            using (HttpResponseMessage response = APIhelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    CurrencyDetails = await response.Content.ReadAsAsync<currencyDetailsModel>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

            return CurrencyDetails;

        }
    }
}
