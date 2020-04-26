using System;
using System.Collections.Generic;
using System.Dynamic;

namespace PowerTrader.Class.Indicator
{
    public class MovingAverage: IndicatorBase
    {
        public int Period {get;}
        public string Source {get;}
        

        public MovingAverage(string sourceField = "Close", int period = 0, List<dynamic> sourceData = null)
        {
            Period = period;
            Source = sourceField;
            InitializeData(sourceData, sourceField);
        }

        private void InitializeData(List<dynamic> sourceData, string sourceField)
        {
           //sourceData.ForEach(x=>{Calculate(sourceData.PriceDate, sourceData.Close);}); 
        }

        public override string IndicatorFieldName()
        {
            try
            {
                return "MA_" + Period + "_" + Source;
            }
            catch (Exception Ex)
            {
                string s = Ex.Message;
                //log
                throw;
            }
        }

        protected override void Calculate(DateTime time, decimal dataValue)
        {
            DateTime PreviousTime = base.PreviousTime(time);

            
            if (!Values.ContainsKey(time))  Values[time] = new ExpandoObject();
            

            if (Values.Count == 1)
            {
                Values[time].IndicatorFieldName = dataValue;
            }
            else 
            {
                int cnt = (Values.Count > Period ? Period: Values.Count -1);

                Values[time].IndicatorFieldName = (((PreviousValue(time) * cnt) + dataValue)/(cnt + 1));
            }

        }

        
    }
}
