using System;
namespace CIS3285_Unit8_Mac

{
    public interface ITradeValidator
    {
        ValidateTradeData(String[] fields, int currentLine);
    }
}