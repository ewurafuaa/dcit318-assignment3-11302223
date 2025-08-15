using System;

namespace InventoryRecordsSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Inventory Records System ===");
                Console.WriteLine();

                InventoryApp inventoryApp = new InventoryApp();
                
                Console.WriteLine("Seeding sample data...");
                inventoryApp.SeedSampleData();
                
                Console.WriteLine("Saving data to file...");
                inventoryApp.SaveData();
                
                Console.WriteLine("Data saved to file. Clearing memory...");
                inventoryApp.ClearMemory();
                
                Console.WriteLine("Loading data from file...");
                inventoryApp.LoadData();
                
                inventoryApp.PrintAllItems();
                
                Console.WriteLine("System demonstration completed successfully!");
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
