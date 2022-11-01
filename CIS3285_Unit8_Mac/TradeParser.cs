using System;
using System.Collections.Generic;

namespace CIS3285_Unit8_Mac
{
    public class TradeParser : ITradeParser
    {
        ITradeValidator tradeValidator;
        ITradeMapper tradeMapper;

        public TradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
        {
            this.tradeValidator = tradeValidator;
            this.tradeMapper = tradeMapper;
        }

        /// <summary>
        /// Takes a list of strings containing trade data and converts this into a list of TradeRecord objects
        /// </summary>
        /// <param name="lines"> The strings containing the trade data, each string should contain one trade in format of "GBPUSD,1000,1.51"</param>
        /// <returns> A list of TradeRecords, one record for each trade </returns>
        public IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines)
        {
            List<TradeRecord> trades = new List<TradeRecord>();

            var lineCount = 1;
            foreach (var line in lines)
            {
                String[] fields = line.Split(new char[] { ',' });

                if (tradeValidator.ValidateTradeData(fields, lineCount) == false)
                {
                    continue;
                }

                TradeRecord trade = tradeMapper.MapTradeDataToTradeRecord(fields);
                trades.Add(trade);

                lineCount++;
            }
            return trades;
        }

    }
}