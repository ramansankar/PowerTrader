using PowerTrader.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerTrader.Class.Indicator
{
    public abstract class IndicatorBase:IIndicator
    {
        public Dictionary<DateTime, dynamic> Values { get; private set; }

        public virtual string IndicatorFieldName()
        {
            return "";
        }
        public virtual string IndicatorFieldName1()
        {
            return "";
        }
        public virtual string IndicatorFieldName2()
        {
            return "";
        }

        protected dynamic PreviousValue(DateTime beforeDateTime)
        {
            return Values[PreviousTime(beforeDateTime)];
        }

        protected DateTime PreviousTime(DateTime beforeDateTime)
        {
            try
            {
                List<DateTime> z = new List<DateTime>(Values.Keys).Where(d => d < beforeDateTime).ToList();
                z.Sort((x, y) => (-1) * DateTime.Compare(x, y));
                return z.FirstOrDefault();
            }
            catch (Exception Ex)
            {
                string s = Ex.Message;
                //LogException
                throw;
            }
        }

        protected abstract void Calculate(DateTime time, decimal dataValue);
    }
}
