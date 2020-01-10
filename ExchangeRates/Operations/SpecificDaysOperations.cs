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
    class SpecificDaysOperations
    {
        public List<RateModel> SpecificRates = new List<RateModel>();
        public class DataObject
        {
            public string Name { get; set; }
        }
        public async Task<List<RateModel>> GetSpecificDayRates(string tablename, string StartDate, string EndDate = null)
        {

            string url;
            if (EndDate==null)
            {
                url = $"http://api.nbp.pl/api/exchangerates/tables/" + tablename + "/" + StartDate + "?format=json";
            }
            else
            {
                url = $"http://api.nbp.pl/api/exchangerates/tables/" + tablename + "/" + StartDate + "/" + EndDate + "?format=json";
            }
            using (HttpResponseMessage response = APIhelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    SpecificRates = await response.Content.ReadAsAsync<List<RateModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

            return SpecificRates;

        }
    }
}
