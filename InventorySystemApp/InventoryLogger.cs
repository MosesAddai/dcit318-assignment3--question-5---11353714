using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    // Constructor to set file path
    public InventoryLogger(string filePath)
    {
        _filePath = filePath;
    }

    // Add item to the log
    public void Add(T item)
    {
        _log.Add(item);
    }

    // Get all items in the log
    public List<T> GetAll()
    {
        return new List<T>(_log); // Return a copy to maintain encapsulation
    }

    // Save all items to a file (JSON serialization)
    public void SaveToFile()
    {
        string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    // Load items from file into _log (JSON deserialization)
    public void LoadFromFile()
    {
        if (!File.Exists(_filePath))
        {
            _log = new List<T>();
            return;
        }

        string json = File.ReadAllText(_filePath);
        _log = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }
}
