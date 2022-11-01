using System;
namespace CIS3285_Unit8_Mac
{
    public interface ITradeMapper
    {
        TradeRecord MapTradeDataToTradeRecord(String[] fields);
    }
}