using BankingTransactions.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankingTransactions.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetByIdAsync(int id);
        Task<IEnumerable<Account>> GetAllAsync();
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int id);
    }
}
