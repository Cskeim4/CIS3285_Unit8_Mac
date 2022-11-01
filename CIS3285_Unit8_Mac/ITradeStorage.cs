using System;
using System.Collections.Generic;

namespace CIS3285_Unit8_Mac
{
    public interface ITradeStorage
    {
        StoreTrades(IEnumerable<TradeRecord> trades);
    }
}