using CIS3285_Unit8_Mac;
using System;
using System.IO;
using System.Reflection;

namespace CIS3285_Unit8_Mac
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Mac.trades.txt");

            ITradeDataProvider myDataProvider = new TradeDataProvider(tradeStream);
            ITradeValidator tradeValidator = new TradeValidator();
            ITradeMapper tradeMapper = new TradeMapper();
            ITradeParser tradeParser = new TradeParser(tradeValidator, tradeMapper);
            ITradeStorage tradeStorage = new AzureTradeStorage();

            var tradeProcessor = new TradeProcessor(myDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}