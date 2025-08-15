using System;

namespace FinanceManagementSystem
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }

        public Transaction(int id, DateTime date, decimal amount, string category)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Category = category;
        }
    }
}
