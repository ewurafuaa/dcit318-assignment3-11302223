using System;

namespace InventoryRecordsSystem
{
    public class InventoryItem : IInventoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public InventoryItem(int id, string name, int quantity, DateTime dateAdded)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            DateAdded = dateAdded;
        }
    }
}
