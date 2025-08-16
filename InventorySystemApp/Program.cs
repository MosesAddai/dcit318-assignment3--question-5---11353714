using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a logger for InventoryItem and specify file path
        var logger = new InventoryLogger<InventoryItem>("inventory.json");

        // Load existing inventory from file (if any)
        logger.LoadFromFile();

        // Add some new items
        logger.Add(new InventoryItem(1, "Apple", 50, DateTime.Now));
        logger.Add(new InventoryItem(2, "Orange", 30, DateTime.Now));
        logger.Add(new InventoryItem(3, "Banana", 20, DateTime.Now));

        // Save inventory to file
        logger.SaveToFile();

        // Display all items in console
        Console.WriteLine("Current Inventory:");
        foreach (var item in logger.GetAll())
        {
            Console.WriteLine($"{item.Id}: {item.Name}, Qty: {item.Quantity}, Added: {item.DateAdded}");
        }
    }
}
