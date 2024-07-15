using BankingTransactions.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingTransactions
{
    public class BankingContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
