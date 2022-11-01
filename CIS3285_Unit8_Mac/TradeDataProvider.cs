using System;
using System.Collections.Generic;
using System.IO;

namespace CIS3285_Unit8_Mac
{
    public class TradeDataProvider : ITradeDataProvider
    {
        Stream stream;

        public TradeDataProvider(Stream newStream)
        {
            stream = newStream;
        }

        /// <summary>
        /// Read the text file containing the trades. This file should in in the format of one trade per line
        ///    GBPUSD,1000,1.51
        /// </summary>
        /// <param name="stream"> File must be passed in as a Stream. </param>
        /// <returns> Returns a list of strings, one for each string for each line in the file </returns>
        public IEnumerable<string> ReadTradeData()
        {
            // read rows
            List<string> lines = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        } 
    }
}