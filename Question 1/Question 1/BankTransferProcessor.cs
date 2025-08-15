using System;

namespace FinanceManagementSystem
{
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Bank Transfer: Processing GHC {transaction.Amount} for {transaction.Category}");
        }
    }
}
