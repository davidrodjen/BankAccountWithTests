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
    }
}