using System;

namespace FinanceManagementSystem
{
    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Mobile Money: Processing GHC {transaction.Amount} for {transaction.Category}");
        }
    }
}
