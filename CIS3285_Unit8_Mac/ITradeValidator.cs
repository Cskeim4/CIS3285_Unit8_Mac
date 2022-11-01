using System;
namespace CIS3285_Unit8_Mac

{
    public interface ITradeValidator
    {
        bool ValidateTradeData(String[] fields, int currentLine);
    }
}