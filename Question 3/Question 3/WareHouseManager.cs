using System;
using System.Collections.Generic;

namespace WarehouseInventoryManagement
{
    public class WareHouseManager
    {
        private InventoryRepository<ElectronicItem> _electronics;
        private InventoryRepository<GroceryItem> _groceries;

        public WareHouseManager()
        {
            _electronics = new InventoryRepository<ElectronicItem>();
            _groceries = new InventoryRepository<GroceryItem>();
        }

        public void SeedData()
        {
            ElectronicItem electronic1 = new ElectronicItem(1, "Laptop", 10, "Dell", 24);
            ElectronicItem electronic2 = new ElectronicItem(2, "Smartphone", 15, "Samsung", 12);
            ElectronicItem electronic3 = new ElectronicItem(3, "Tablet", 8, "Apple", 12);

            GroceryItem grocery1 = new GroceryItem(101, "Rice", 50, DateTime.Now.AddMonths(6));
            GroceryItem grocery2 = new GroceryItem(102, "Pasta", 30, DateTime.Now.AddMonths(12));
            GroceryItem grocery3 = new GroceryItem(103, "Canned Beans", 25, DateTime.Now.AddYears(2));

            _electronics.AddItem(electronic1);
            _electronics.AddItem(electronic2);
            _electronics.AddItem(electronic3);

            _groceries.AddItem(grocery1);
            _groceries.AddItem(grocery2);
            _groceries.AddItem(grocery3);
        }

        public InventoryRepository<ElectronicItem> Electronics => _electronics;
        public InventoryRepository<GroceryItem> Groceries => _groceries;

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            var items = repo.GetAllItems();
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Quantity: {item.Quantity}");
            }
            Console.WriteLine();
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Successfully increased stock for item {id} by {quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Successfully removed item {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
        }
    }
}
