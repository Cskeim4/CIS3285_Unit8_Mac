using System;
using System.Collections.Generic;

namespace CIS3285_Unit8_Mac
{
    public interface ITradeParser
    {
        IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines);
    }
}