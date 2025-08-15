using System;

namespace InventoryRecordsSystem
{
    public class InventoryApp
    {
        private InventoryLogger<InventoryItem> _logger;

        public InventoryApp()
        {
            _logger = new InventoryLogger<InventoryItem>("inventory.txt");
        }

        public void SeedSampleData()
        {
            InventoryItem item1 = new InventoryItem(1, "Laptop", 10, DateTime.Now.AddDays(-30));
            InventoryItem item2 = new InventoryItem(2, "Mouse", 50, DateTime.Now.AddDays(-25));
            InventoryItem item3 = new InventoryItem(3, "Keyboard", 25, DateTime.Now.AddDays(-20));
            InventoryItem item4 = new InventoryItem(4, "Monitor", 15, DateTime.Now.AddDays(-15));
            InventoryItem item5 = new InventoryItem(5, "Headphones", 30, DateTime.Now.AddDays(-10));

            _logger.Add(item1);
            _logger.Add(item2);
            _logger.Add(item3);
            _logger.Add(item4);
            _logger.Add(item5);
        }

        public void SaveData()
        {
            _logger.SaveToFile();
        }

        public void LoadData()
        {
            _logger.LoadFromFile();
        }

        public void PrintAllItems()
        {
            var items = _logger.GetAll();
            Console.WriteLine("=== All Inventory Items ===");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}, Date Added: {item.DateAdded:yyyy-MM-dd}");
            }
            Console.WriteLine();
        }

        public void ClearMemory()
        {
            _logger.ClearLog();
        }
    }
}
