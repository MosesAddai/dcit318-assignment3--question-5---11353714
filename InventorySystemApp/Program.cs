using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "inventory.json";

        // Step 1: Create an instance of InventoryApp
        InventoryApp app = new InventoryApp(filePath);

        // Step 2: Seed sample data
        app.SeedSampleData();

        // Step 3: Save data to disk
        app.SaveData();
        Console.WriteLine("Data seeded and saved successfully.\n");

        // Step 4: Clear memory to simulate a new session
        app = new InventoryApp(filePath);

        // Step 5: Load data from file
        app.LoadData();

        // Step 6: Print all items to confirm recovery
        app.PrintAllItems();
    }
}
