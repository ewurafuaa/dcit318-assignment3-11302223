using System;

namespace FinanceManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FinanceApp financeApp = new FinanceApp();
                financeApp.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
