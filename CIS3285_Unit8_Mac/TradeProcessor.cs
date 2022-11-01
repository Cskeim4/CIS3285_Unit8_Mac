using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CIS3285_Unit8_Mac
{
    public class TradeProcessor
    {
        ITradeDataProvider myDataProvider;
        ITradeParser myTradeParser;
        ITradeStorage myTradeStorage;

        public TradeProcessor(ITradeDataProvider myDataProvider, ITradeParser myTradeParser, ITradeStorage myTradeStorage)
        {
            this.myDataProvider = myDataProvider;
            this.myTradeParser = myTradeParser;
            this.myTradeStorage = myTradeStorage;
        }

        /// <summary>
        /// Main routine that processes the trade file
        /// </summary>
        /// <param name="stream"> The text file contianing the trade data </param>
        public void ProcessTrades()
        {
            var lines = myDataProvider.ReadTradeData();
            var trades = myTradeParser.ParseTrades(lines);

            myTradeStorage.StoreTrades(trades);
        }
    }
}