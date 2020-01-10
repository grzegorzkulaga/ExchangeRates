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
    class GoldRatesOperations
    {
        public List<GoldRateModel> goldRates = new List<GoldRateModel>();
        public async Task<List<GoldRateModel>> GetGoldRates()
        {

            string url = $"http://api.nbp.pl/api/cenyzlota/last/30/?format=json";

            using (HttpResponseMessage response = APIhelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    goldRates = await response.Content.ReadAsAsync<List<GoldRateModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

            return goldRates;

        }
    }
}
