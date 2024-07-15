using System;
using System.ComponentModel.DataAnnotations;

namespace BankingTransactions.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountNumber { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive", nameof(amount));
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive", nameof(amount));
            if (Balance < amount) throw new InvalidOperationException("Insufficient balance");
            Balance -= amount;
        }
    }
}
