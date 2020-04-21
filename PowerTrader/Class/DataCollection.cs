using PowerTrader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTrader.Class
{
    public class DataCollection
    {
        public List<DataRequest> Requests {get; set; }
        public List<List<DataBar>> SecurityData{get;set; }

    }
}
