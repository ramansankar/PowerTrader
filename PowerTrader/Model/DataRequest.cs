using PowerTrader.Enumerator;

namespace PowerTrader.Model
{
    public class DataRequest
    {
        public string Ticker{get; set; }
        public SecurityType SecurityType { get; set; }
        public BarSize BarSize { get; set; }

        public DataRequest(string ticker, SecurityType securityType, BarSize barSize)
        {
            Ticker = ticker;
            SecurityType = securityType;
            BarSize = barSize;
        }

        public DataRequest(): this("", SecurityType.NONE, BarSize.NONE)         {}
    }
}
