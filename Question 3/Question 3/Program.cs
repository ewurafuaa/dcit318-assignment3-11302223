using System;

namespace WarehouseInventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Warehouse Inventory Management System ===");
                Console.WriteLine();

                WareHouseManager warehouseManager = new WareHouseManager();
                warehouseManager.SeedData();

                Console.WriteLine("=== All Grocery Items ===");
                warehouseManager.PrintAllItems(warehouseManager.Groceries);

                Console.WriteLine("=== All Electronic Items ===");
                warehouseManager.PrintAllItems(warehouseManager.Electronics);

                Console.WriteLine("=== Testing Exception Handling ===");
                Console.WriteLine();

                try
                {
                    ElectronicItem duplicateItem = new ElectronicItem(1, "Duplicate Laptop", 5, "HP", 12);
                    warehouseManager.Electronics.AddItem(duplicateItem);
                }
                catch (DuplicateItemException ex)
                {
                    Console.WriteLine($"Caught DuplicateItemException: {ex.Message}");
                }

                try
                {
                    warehouseManager.Groceries.RemoveItem(999);
                }
                catch (ItemNotFoundException ex)
                {
                    Console.WriteLine($"Caught ItemNotFoundException: {ex.Message}");
                }

                try
                {
                    warehouseManager.Electronics.UpdateQuantity(1, -5);
                }
                catch (InvalidQuantityException ex)
                {
                    Console.WriteLine($"Caught InvalidQuantityException: {ex.Message}");
                }

                Console.WriteLine();
                Console.WriteLine("Exception handling demonstration completed successfully!");
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
