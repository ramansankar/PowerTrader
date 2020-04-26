using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTrader.Class.Common
{
    static class Indicators
    {
        public static decimal MovingAverage(int period, decimal value, decimal previousValue = 0, long noOfPriorValues = 0 )
        {
            try
            {
                if (noOfPriorValues == 0)
                {
                    return value;
                }
                else
                {
                    return (((noOfPriorValues* previousValue) + value)/(1 + noOfPriorValues));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
