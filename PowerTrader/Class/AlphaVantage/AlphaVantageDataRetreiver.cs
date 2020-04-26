using AlphaVantage.Net.Stocks;
using AlphaVantage.Net.Stocks.TimeSeries;
using PowerTrader.Enumerator;
using PowerTrader.Interface;
using PowerTrader.Model;
using PowerTrader.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<PriceData> GetHistoricalDataAsync(DataRequest Request)
        {
            var client = new AlphaVantageStocksClient(Constants.AlphaVantageApiKey);
            var HistoricalBarCollection = new PriceData(Request);
            //HistoricalBarCollection.PriceDataChanged += HistoricalBarCollection_PriceDataChanged;
            StockTimeSeries timeSeries;
            switch (Request.BarSize)
            {
                case BarSize.DAY:
                    timeSeries = await client.RequestDailyTimeSeriesAsync(Request.Ticker, TimeSeriesSize.Full, adjusted: false);
                    break;
                case BarSize.WEEK:
                    timeSeries = await client.RequestWeeklyTimeSeriesAsync (Request.Ticker, adjusted: false);
                    break;
                case BarSize.MONTH:
                    timeSeries = await client.RequestMonthlyTimeSeriesAsync(Request.Ticker, adjusted: false);
                    break;
                default:
                    timeSeries = await client.RequestIntradayTimeSeriesAsync  (Request.Ticker, (IntradayInterval) Request.BarSize, TimeSeriesSize.Full);
                    break;
            }

            ((List<StockDataPoint>) timeSeries.DataPoints).ForEach (bar=> HistoricalBarCollection.SecurityPriceData.Add(new DataBar(bar)));
            return HistoricalBarCollection;
        }

        private void HistoricalBarCollection_PriceDataChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Something happened");
        }
    }
}
