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
/// <summary>
/// asynchronous method which return today rates from specific table. Data taken form NBP API
/// </summary>
    public class RatesProcessor
    {
        public List<RateModel> todayRates = new List<RateModel>();
        public class DataObject
        {
            public string Name { get; set; }
        }
        public async Task<List<RateModel>> GetTodaysRates(string tablename)
        {
     
            string url = $"http://api.nbp.pl/api/exchangerates/tables/"+ tablename + "/?format=json";

                using (HttpResponseMessage response = APIhelper.ApiClient.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                       todayRates =await response.Content.ReadAsAsync<List<RateModel>>();
                }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }

                }

            return todayRates;
           
        }
    }
}
