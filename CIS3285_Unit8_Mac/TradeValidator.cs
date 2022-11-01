using System;
namespace CIS3285_Unit8_Mac
{
    public class TradeValidator : ITradeValidator
    {
        ConsoleLogger myLogger;

        public TradeValidator()
        {
            myLogger = new ConsoleLogger();
        }

        /// <summary>
        /// Checks the formate on a single line in the trade file.
        /// </summary>
        /// <param name="fields"> The string must be split into three components before calling </param>
        /// <param name="currentLine"> This is the current line number in the file, used to report errors</param>
        /// <returns> true if all the checks pass </returns>
        public bool ValidateTradeData(String[] fields, int currentLine)
        {

            if (fields.Length != 3)
            {
                myLogger.LogMessage("WARN: Line {0} malformed. Only {1} field(s) found.", currentLine, fields.Length);
                return false;
            }

            if (fields[0].Length != 6)
            {
                myLogger.LogMessage("WARN: Trade currencies on line {0} malformed: '{1}'", currentLine, fields[0]);
                return false;
            }

            //Check if fields contains a negative
            if (fields[1].Contains("-") || fields[2].Contains("-"))
            {
                myLogger.LogMessage("WARN: Negative found in the text, negative numbers are not allowed.");
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                myLogger.LogMessage("WARN: Trade amount on line {0} not a valid integer: '{1}'", currentLine, fields[1]);
                return false;
            }

            decimal tradePrice;
            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                myLogger.LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'", currentLine, fields[2]);
                return false;
            }
            //if (tradePrice < 0)
            //{
            //    LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'", currentLine, fields[2]);
            //    return false;
            //}
            return true;
        }
    }
}