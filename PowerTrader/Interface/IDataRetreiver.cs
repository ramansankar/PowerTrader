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

        System.Threading.Tasks.Task<List<DataBar>> GetHistoricalDataAsync(SecurityType securityType, string ticker, BarSize barSize, DateTime? endDate= null );
        string GetApiKey();
    }
}
