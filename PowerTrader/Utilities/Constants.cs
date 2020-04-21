using System.Configuration;

namespace PowerTrader.Utilities
{
    public static class Constants
    {
        public static readonly string AlphaVantageApiKey = "";
        public static readonly string QuandlAPIKey = ""; 

        static Constants()
        {
            AlphaVantageApiKey = ConfigurationSettings.AppSettings.Get("AlphaVantageAPIKey");
            QuandlAPIKey = ConfigurationSettings.AppSettings.Get("QuandlAPIKey");
            

        }
    }
}
