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
    public class SpecificDaysOperations
    {
        public List<RateModel> SpecificRates = new List<RateModel>();
        public class DataObject
        {
            public string Name { get; set; }
        }
        /// <summary>
        /// asynchronous method which return range of currency rates from specific table. Data is taken from NBP API
        /// </summary>
        /// <param name="tablename">Name of one of three("A","B","C") tables which are given from NBP</param>
        /// <param name="StartDate">Date in string format, which is start point of date range</param>
        /// <param name="EndDate">Date in string format, which is end point of date range</param>
        /// <returns></returns>
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
