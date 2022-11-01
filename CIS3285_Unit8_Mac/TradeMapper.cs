using System;
namespace CIS3285_Unit8_Mac
{
    public class TradeMapper : ITradeMapper
    {
        public TradeMapper()
        {
        }

        const float LotSize = 100000f;

        /// <summary>
        /// Converts a string containing the trade data into a TradeRecord object
        /// </summary>
        /// <param name="fields"> The string must be split into three components before calling </param>
        /// <returns> A TradeRecord object containing the trade data</returns>
        public TradeRecord MapTradeDataToTradeRecord(String[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            int tradeAmount = int.Parse(fields[1]);
            decimal tradePrice = decimal.Parse(fields[2]);

            // calculate values
            var trade = new TradeRecord();
            trade.SourceCurrency = sourceCurrencyCode;
            trade.DestinationCurrency = destinationCurrencyCode;
            trade.Lots = tradeAmount / LotSize;
            trade.Price = tradePrice;

            return trade;
        }

    }
}