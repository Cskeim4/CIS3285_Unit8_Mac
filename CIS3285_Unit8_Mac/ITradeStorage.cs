using System;
using System.Collections.Generic;

namespace CIS3285_Unit8_Mac
{
    public interface ITradeStorage
    {
        void StoreTrades(IEnumerable<TradeRecord> trades);
    }
}