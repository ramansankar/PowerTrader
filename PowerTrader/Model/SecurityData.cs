using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTrader.Model
{
    public class SecurityData
    {
        public DataRequest Request {get; set; }
        public List<DataBar> PriceData {get; set; }
        public ExpandoObject TechnicalIndicators {get; set; }
        public ExpandoObject Signals{get; set; }

        public SecurityData(List<DataBar> priceData = null)
        {
            PriceData = priceData;
        }

        private void RegisterRequest()
        {

        }
    }
}
