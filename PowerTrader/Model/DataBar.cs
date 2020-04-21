using AlphaVantage.Net.Stocks.TimeSeries;
using System;

namespace PowerTrader.Model
{
    public class DataBar
    {
        public readonly decimal Open;
        public readonly decimal Close;
        public readonly decimal High;
        public readonly decimal Low;
        public readonly long Volume;
        public readonly DateTime PriceDate;

        public DataBar(DateTime priceDate, decimal open = 0, decimal close = 0, decimal high = 0, decimal low = 0, long volume = 0)
        {
            PriceDate = priceDate;
            Open = open;
            Close = close;
            High = high;
            Low = low;
            Volume = volume;
        }
        public DataBar() : this(priceDate: DateTime.Now, open: 0, close: 0, high: 0, low: 0, volume: 0){ }

        public DataBar(StockDataPoint stockDataPoint) : this(stockDataPoint.Time, stockDataPoint.OpeningPrice, stockDataPoint.ClosingPrice , stockDataPoint.HighestPrice, stockDataPoint.LowestPrice, stockDataPoint.Volume) { }

    }
}
