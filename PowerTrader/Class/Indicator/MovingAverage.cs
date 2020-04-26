using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTrader.Class.Indicator
{
    public class MovingAverage: IndicatorBase
    {
        public int Period {get; private set; }
        public string Source { get; private set; } 
        public MovingAverage(string source = "CLOSE", int period = 0)
        {
            Period = period;
            Source = source;
        }
    }
}
