using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
        public class Rate
        {
            public string no { get; set; }
            public string effectiveDate { get; set; }
            public double mid { get; set; }
        }

        public class currencyDetailsModel
        {
            public string table { get; set; }
            public string currency { get; set; }
            public string code { get; set; }
            public List<Rate> rates { get; set; }
        }

}
