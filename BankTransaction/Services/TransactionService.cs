using BankingTransactions.Interfaces;
using BankingTransactions.Models;
using System;
using System.Threading.Tasks;

namespace BankingTransactions.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;

        public TransactionService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task DepositAsync(int accountId, decimal amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) throw new ArgumentException("Invalid account ID");

            account.Deposit(amount);
            await _accountRepository.UpdateAsync(account);
        }

        public async Task WithdrawAsync(int accountId, decimal amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null) throw new ArgumentException("Invalid account ID");

            account.Withdraw(amount);
            await _accountRepository.UpdateAsync(account);
        }

        public async Task TransferAsync(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _accountRepository.GetByIdAsync(fromAccountId);
            var toAccount = await _accountRepository.GetByIdAsync(toAccountId);

            if (fromAccount == null || toAccount == null) throw new ArgumentException("Invalid account ID");

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);

            await _accountRepository.UpdateAsync(fromAccount);
            await _accountRepository.UpdateAsync(toAccount);
        }
    }
}
