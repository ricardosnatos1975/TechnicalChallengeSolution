namespace BankingTransactions.Models
{
    public class CurrentAccount : Account
    {
        public decimal OverdraftLimit { get; set; }

        public new void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive", nameof(amount));
            if (Balance + OverdraftLimit < amount) throw new InvalidOperationException("Insufficient balance");
            Balance -= amount;
        }
    }
}
