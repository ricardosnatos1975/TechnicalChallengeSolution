using BankingTransactions.Interfaces;
using BankingTransactions.Models;
using BankingTransactions.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BankingTransactionsTests.Services
{
    public class TransactionServiceTests
    {
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly ITransactionService _transactionService;

        public TransactionServiceTests()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _transactionService = new TransactionService(_accountRepositoryMock.Object);
        }

        [Fact]
        public async Task DepositAsync_ShouldIncreaseBalance()
        {
            // Arrange
            var account = new Account { Id = 1, Balance = 100 };
            _accountRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(account);

            // Act
            await _transactionService.DepositAsync(1, 50);

            // Assert
            Assert.Equal(150, account.Balance);
            _accountRepositoryMock.Verify(repo => repo.UpdateAsync(account), Times.Once);
        }

        [Fact]
        public async Task WithdrawAsync_ShouldDecreaseBalance()
        {
            // Arrange
            var account = new Account { Id = 1, Balance = 100 };
            _accountRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(account);

            // Act
            await _transactionService.WithdrawAsync(1, 50);

            // Assert
            Assert.Equal(50, account.Balance);
            _accountRepositoryMock.Verify(repo => repo.UpdateAsync(account), Times.Once);
        }

        [Fact]
        public async Task TransferAsync_ShouldTransferAmount()
        {
            // Arrange
            var fromAccount = new Account { Id = 1, Balance = 100 };
            var toAccount = new Account { Id = 2, Balance = 50 };
            _accountRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(fromAccount);
            _accountRepositoryMock.Setup(repo => repo.GetByIdAsync(2)).ReturnsAsync(toAccount);

            // Act
            await _transactionService.TransferAsync(1, 2, 25);

            // Assert
            Assert.Equal(75, fromAccount.Balance);
            Assert.Equal(75, toAccount.Balance);
            _accountRepositoryMock.Verify(repo => repo.UpdateAsync(fromAccount), Times.Once);
            _accountRepositoryMock.Verify(repo => repo.UpdateAsync(toAccount), Times.Once);
        }
    }
}
