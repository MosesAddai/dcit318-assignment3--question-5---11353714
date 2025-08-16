using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class InventoryLogger<T> where T : IInventoryEntity
{
    private List<T> _log = new List<T>();
    private string _filePath;

    public InventoryLogger(string filePath)
    {
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

    // Save inventory to file with exception handling
    public void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath, false))
            {
                string json = JsonSerializer.Serialize(_log, new JsonSerializerOptions { WriteIndented = true });
                writer.Write(json);
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: Access to file denied - {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: IO exception occurred while saving file - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while saving file: {ex.Message}");
        }
    }

    // Load inventory from file with exception handling
    public void LoadFromFile()
    {
        if (!File.Exists(_filePath))
        {
            _log = new List<T>();
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = reader.ReadToEnd();
                _log = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Error: Access to file denied - {ex.Message}");
            _log = new List<T>();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error: IO exception occurred while loading file - {ex.Message}");
            _log = new List<T>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error: Failed to parse JSON - {ex.Message}");
            _log = new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error while loading file: {ex.Message}");
            _log = new List<T>();
        }
    }
}
