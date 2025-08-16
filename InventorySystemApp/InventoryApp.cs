using System;

public class InventoryApp
{
    private InventoryLogger<InventoryItem> _logger;

    // Constructor sets the file path for logger
    public InventoryApp(string filePath)
    {
        _logger = new InventoryLogger<InventoryItem>(filePath);
    }

    // Seed sample data into the logger
    public void SeedSampleData()
    {
        _logger.Add(new InventoryItem(1, "Apple", 50, DateTime.Now));
        _logger.Add(new InventoryItem(2, "Orange", 30, DateTime.Now));
        _logger.Add(new InventoryItem(3, "Banana", 20, DateTime.Now));
        _logger.Add(new InventoryItem(4, "Mango", 40, DateTime.Now));
        _logger.Add(new InventoryItem(5, "Grapes", 25, DateTime.Now));
    }

    // Save all logged data to file
    public void SaveData()
    {
        _logger.SaveToFile();
    }

    // Load data from file into logger
    public void LoadData()
    {
        _logger.LoadFromFile();
    }

    // Print all items from the logger
    public void PrintAllItems()
    {
        var items = _logger.GetAll();

        if (items.Count == 0)
        {
            Console.WriteLine("No items in inventory.");
            return;
        }

        Console.WriteLine("Inventory Items:");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}: {item.Name}, Qty: {item.Quantity}, Added: {item.DateAdded}");
        }
    }
}
