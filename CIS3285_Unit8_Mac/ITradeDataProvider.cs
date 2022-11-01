using System;
using System.Collections.Generic;

namespace CIS3285_Unit8_Mac
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> ReadTradeData();
    }
}