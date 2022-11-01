using System;
using System.Collections.Generic;
using System.Linq;

namespace CIS3285_Unit8_Mac
{
    public class AzureTradeStorage : ITradeStorage
    {
        ConsoleLogger myLogger = new ConsoleLogger();

        /// <summary>
        /// Write the trade records to the database
        /// </summary>
        /// <param name="trades"> A list of TradeRecord objects </param>
        public void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            myLogger.LogMessage("INFO: Connecting to database");
            // Template for connection string from database connection file
            //    The @ sign allows for back slashes
            //    Watch for double quotes which must be escaped using "" 
            //    Watch for extra spaces after C: and avoid paths with - hyphens -
            string genericConnectString = @"Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True;";
            // The datadirConnectString connection string uses |DataDirectory| 
            //    and assumes the tradedatabase.mdf file is stored in 
            //    SingleResponsibilityPrinciple\bin\Debug 
            string datadirConnectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\tradedatabase.mdf;Integrated Security=True;Connect Timeout=30;";
            // This users the Azure connection string
            string azureConnectString = @"Data Source=cis3115-server.database.windows.net;Initial Catalog=CIS3115;User ID=cis3115;Password=Saints4SQL;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // Change the connection string used to match the one you want
            using (var connection = new System.Data.SqlClient.SqlConnection(azureConnectString))
            {
                myLogger.LogMessage("INFO:Going to open database connection");
                connection.Open();
                myLogger.LogMessage("INFO:Database connection OPEN");

                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);
                        myLogger.LogMessage("INFO: Adding trade to database...");

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                connection.Close();
            }

            myLogger.LogMessage("INFO: {0} trades processed", trades.Count());
        }

    }
}