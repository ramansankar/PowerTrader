using PowerTrader.Enumerator;
using PowerTrader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTrader.Interface
{
    interface IDataRetreiver
    {

        Task<PriceData> GetHistoricalDataAsync(DataRequest Request);
        string GetApiKey();
    }
}
