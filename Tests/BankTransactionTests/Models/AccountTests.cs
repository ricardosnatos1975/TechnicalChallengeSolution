using BankingTransactions.Models;
using Xunit;
using System;

namespace BankingTransactionsTests.Models
{
    public class AccountTests
    {
        [Fact]
        public void Deposit_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new Account { Balance = 100 };

            // Act
            account.Deposit(50);

            // Assert
            Assert.Equal(150, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldDecreaseBalance()
        {
            // Arrange
            var account = new Account { Balance = 100 };

            // Act
            account.Withdraw(50);

            // Assert
            Assert.Equal(50, account.Balance);
        }

        [Fact]
        public void Withdraw_ShouldThrowException_WhenInsufficientBalance()
        {
            // Arrange
            var account = new Account { Balance = 100 };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
        }
    }
}
