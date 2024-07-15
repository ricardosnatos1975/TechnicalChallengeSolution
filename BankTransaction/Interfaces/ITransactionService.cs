using System.Threading.Tasks;

namespace BankingTransactions.Interfaces
{
    public interface ITransactionService
    {
        Task DepositAsync(int accountId, decimal amount);
        Task WithdrawAsync(int accountId, decimal amount);
        Task TransferAsync(int fromAccountId, int toAccountId, decimal amount);
    }
}
