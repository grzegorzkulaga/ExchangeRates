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
    class RatesProcessor
    {
        public class DataObject
        {
            public string Name { get; set; }
        }
        public async Task<List<RateModel>> GetTodaysRates()
        {
            string url = $"http://api.nbp.pl/api/exchangerates/tables/A/today?format=json";
           
            //HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            using (HttpResponseMessage response = APIhelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    //string json = new WebClient().DownloadString(url);
                    //var ListOfRates = JsonConvert.DeserializeObject<List<RateModel>>(json);
                   
                    var rates = await response.Content.ReadAsAsync<List<RateModel>>();
                    return rates;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
              
            }
        }
    }
}
