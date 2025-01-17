﻿using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using CIS3285_Unit8_Mac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CIS3285_Unit8_Tests
{

    [TestClass]
    public class UnitTest1
    {

        private int CountDbRecords()
        {
            string azureConnectString = @"Data Source=cis3115-server.database.windows.net;Initial Catalog=CIS3115;User ID=cis3115;Password=Saints4SQL;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var connection = new System.Data.SqlClient.SqlConnection(azureConnectString))
            //using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True;"))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    //connection.Open();
                }
                string myScalarQuery = "SELECT COUNT(*) FROM trade";
                SqlCommand myCommand = new SqlCommand(myScalarQuery, connection);
                myCommand.Connection.Open();
                int count = (int)myCommand.ExecuteScalar();
                connection.Close();
                return count;
            }
        }

        [TestMethod()]
        public void TestOneGoodTrade()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.goodTrades1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        //Process Trades Unit Test #1
        [TestMethod]
        public void NegativeTradeAmountNotAllowed()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.negativeTrades1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore, countAfter);
        }

        //Process Trades Unit Test #2
        [TestMethod]
        public void incompleteNumbersInTrade()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.incompleteTradeNumbers1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore, countAfter);
        }

        //Process Trades Unit Test #3
        [TestMethod]
        public void incompleteStringInTrade()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.incompleteTradeString1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore, countAfter);
        }

        //Process Trades Unit Test #4
        [TestMethod]
        public void CanProcessManyTrades()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.manyTrades1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore + 10, countAfter);
        }

        //Read Trade Data Unit Test #1
        [TestMethod]
        public void ReadEmptyTradeFile()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.emptyTradesFile1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore, countAfter);
        }

        //Read Trade Data Unit Test #2
        [TestMethod]
        public void TradeParametersCorrectOrder()
        {
            //Arrange
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CIS3285_Unit8_Tests.incorrectTradeParameterOrder1.txt");
            var tradeProcessor = new TradeProcessor();

            //Act
            int countBefore = CountDbRecords();
            tradeProcessor.ProcessTrades(tradeStream);

            //Assert
            int countAfter = CountDbRecords();
            Assert.AreEqual(countBefore, countAfter);
        }
    }
}