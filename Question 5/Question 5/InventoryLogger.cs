using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InventoryRecordsSystem
{
    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private List<T> _log;
        private string _filePath;

        public InventoryLogger(string filePath)
        {
            _log = new List<T>();
            _filePath = filePath;
        }

        public void Add(T item)
        {
            _log.Add(item);
        }

        public List<T> GetAll()
        {
            return new List<T>(_log);
        }

        public void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var item in _log)
                    {
                        if (item is InventoryItem inventoryItem)
                        {
                            string line = $"{inventoryItem.Id},{inventoryItem.Name},{inventoryItem.Quantity},{inventoryItem.DateAdded:yyyy-MM-dd}";
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        string line;
                        _log.Clear();
                        
                        while ((line = reader.ReadLine()) != null)
                        {
                            try
                            {
                                string[] parts = line.Split(',');
                                if (parts.Length == 4)
                                {
                                    int id = int.Parse(parts[0]);
                                    string name = parts[1];
                                    int quantity = int.Parse(parts[2]);
                                    DateTime dateAdded = DateTime.Parse(parts[3]);
                                    
                                    if (typeof(T) == typeof(InventoryItem))
                                    {
                                        var item = new InventoryItem(id, name, quantity, dateAdded);
                                        _log.Add((T)(object)item);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error parsing line: {line}, Error: {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }

        public void ClearLog()
        {
            _log.Clear();
        }
    }
}
