using System;
using System.Collections.Generic;

namespace FinanceManagementSystem
{
    public class FinanceApp
    {
        private List<Transaction> _transactions;

        public FinanceApp()
        {
            _transactions = new List<Transaction>();
        }

        public void Run()
        {
            Console.WriteLine("=== Finance Management System ===");
            Console.WriteLine();

            SavingsAccount savingsAccount = new SavingsAccount("SA001", 1000);
            Console.WriteLine($"Initial balance: GHC {savingsAccount.Balance}");
            Console.WriteLine();

            Transaction transaction1 = new Transaction(1, DateTime.Now, 50, "Groceries");
            Transaction transaction2 = new Transaction(2, DateTime.Now, 100, "Utilities");
            Transaction transaction3 = new Transaction(3, DateTime.Now, 75, "Entertainment");

            MobileMoneyProcessor mobileMoneyProcessor = new MobileMoneyProcessor();
            BankTransferProcessor bankTransferProcessor = new BankTransferProcessor();
            CryptoWalletProcessor cryptoWalletProcessor = new CryptoWalletProcessor();

            mobileMoneyProcessor.Process(transaction1);
            savingsAccount.ApplyTransaction(transaction1);

            bankTransferProcessor.Process(transaction2);
            savingsAccount.ApplyTransaction(transaction2);

            cryptoWalletProcessor.Process(transaction3);
            savingsAccount.ApplyTransaction(transaction3);

            _transactions.Add(transaction1);
            _transactions.Add(transaction2);
            _transactions.Add(transaction3);

            Console.WriteLine();
            Console.WriteLine($"Total transactions processed: {_transactions.Count}");
        }
    }
}
