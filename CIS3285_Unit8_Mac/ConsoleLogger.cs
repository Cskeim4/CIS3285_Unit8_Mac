using System;
namespace CIS3285_Unit8_Mac
{
    public class ConsoleLogger
    {
        public ConsoleLogger()
        {
        }

        public void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
