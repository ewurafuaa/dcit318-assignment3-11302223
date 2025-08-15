using System;

namespace FinanceManagementSystem
{
    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"Crypto Wallet: Processing GHC {transaction.Amount} for {transaction.Category}");
        }
    }
}
