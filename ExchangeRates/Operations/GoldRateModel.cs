using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
   public class GoldRateModel
    {
        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("cena")]
        public double cena { get; set; }
    }
}
