using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{ 
    public class RateModel
    {   [JsonProperty("table")]
        public string table { get; set; }

        [JsonProperty("no")]
        public string no { get; set; }

        [JsonProperty("effectiveDate")]
        public string effectiveDate { get; set; }


        [JsonProperty("rates")]
        public List<Rates> Rates { get; set; }

       
    }
    public class Rates
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("Mid")]
        public double Mid { get; set; }
    }

}