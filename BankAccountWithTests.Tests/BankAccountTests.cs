using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountWithTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountWithTests.Tests
{
    [TestClass()]
    public class BankAccountTests
    {   
        [TestMethod]
        [DataRow("123")]
        [DataRow("1234567890")]
        [DataRow("ABC123")]
        [DataRow("ABC234#!@")]
        [DataRow("☻")]
        public void Constructor_ValidAccNum_SetsAccountNumber(string accNum)
        {
            // Arrange/Act
            BankAccount acc = new BankAccount(accNum);

            // Assert
            Assert.AreEqual(accNum, acc.AccountNumber);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void Constructor_InvalidAccNum_ThrowsArgument(string accNum)
        {
            // Arrange/Act
            Assert.ThrowsException<ArgumentException>(() => new BankAccount(accNum));

            // Refactor into separate test
            BankAccount acc = new BankAccount("123");
            Assert.ThrowsException<ArgumentException>(() => acc.AccountNumber = accNum);


        }

        [TestMethod()]
        public void Deposit_PositiveValue_AddsToBalance() //adding stuff to this test, to test
        {
            // Arrange - create objects and variables
            BankAccount acc = new BankAccount("123");
            double depositAmount = 100.0;
            //double initialBalance = 0.0;
            double expectedBalance = 100.0;

            // Act - Call method under test
            acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmountWithCents_AddsToBalance()
        {
            // Arrange - Create Objects and Variables
            BankAccount acc = new BankAccount("123");
            double depositAmount = 10.55;
            double expectedBalance = 10.55;

            // Act - Call method under test
            acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, acc.Balance);
        }




        [DataRow(100)]
        [DataRow(100.99)]
        [DataRow(9.000001)] // We are not losing precision for this
        [TestMethod]
        public void Deposit_PositiveAmount_ReturnsUpdatedBalance(double depositAmt)
        {

            // Arrange
            BankAccount acc = new BankAccount("123");
            double initialBalance = 0.0;
            double expectedBalance = initialBalance + depositAmt;

            // Act
            double returnedBalance = acc.Deposit(depositAmt);

            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
            // Assert.AreEqual(expectedBalance, acc.Balance);


        }
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-10000.01)]
        [TestMethod]
        public void Deposit_NegativeAmount_ThrowsArgumentException(double depositAmt)
        {
            // Arrange
            BankAccount acc = new BankAccount("123");
            

            // Act
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(depositAmt));

            // Assert
        }
    }
}