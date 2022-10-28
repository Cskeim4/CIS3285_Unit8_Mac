using CIS3285_Unit8_Mac;
using System;
using System.Reflection;

namespace CIS3285_Unit8_Mac
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Mac.trades.txt");

            var tradeProcessor = new TradeProcessor();
            tradeProcessor.ProcessTrades(tradeStream);

            Console.ReadKey();
        }
    }
}
