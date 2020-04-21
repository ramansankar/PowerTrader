using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.TimeSeries;
using PowerTrader.Enumerator;
using PowerTrader.Interface;
using PowerTrader.Model;
using PowerTrader.Utilities;
using System;
using System.Collections.Generic;

namespace PowerTrader.Class
{
    public class AlphaVantageDataRetreiver : IDataRetreiver
    {
        public string GetApiKey()
        {
            try
            {
                return Constants.AlphaVantageApiKey;
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        public async System.Threading.Tasks.Task<List<DataBar>> GetHistoricalDataAsync(SecurityType securityType, string ticker, BarSize barSize, DateTime? endDate = null)
        {
            var client = new AlphaVantageStocksClient(Constants.AlphaVantageApiKey);
            var HistoricalBarCollection = new List<DataBar>();
            StockTimeSeries timeSeries;
            switch (barSize)
            {
                case BarSize.DAY:
                    timeSeries = await client.RequestDailyTimeSeriesAsync(ticker, TimeSeriesSize.Full, adjusted: false);
                    break;
                case BarSize.WEEK:
                    timeSeries = await client.RequestWeeklyTimeSeriesAsync (ticker, adjusted: false);
                    break;
                case BarSize.MONTH:
                    timeSeries = await client.RequestMonthlyTimeSeriesAsync(ticker, adjusted: false);
                    break;
                default:
                    timeSeries = await client.RequestIntradayTimeSeriesAsync  (ticker, (IntradayInterval) barSize, TimeSeriesSize.Full);
                    break;
            }

            ((List<StockDataPoint>) timeSeries.DataPoints).ForEach (bar=> HistoricalBarCollection.Add(new DataBar(bar)));
            return HistoricalBarCollection;
        }
    }
}
