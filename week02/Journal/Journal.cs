using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(fileName, json);
    }

    public bool LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return false;
        }

        string json = File.ReadAllText(fileName);
        List<Entry>? loadedEntries = JsonSerializer.Deserialize<List<Entry>>(json);

        if (loadedEntries is null)
        {
            return false;
        }

        _entries = loadedEntries;
        return true;
    }
}
