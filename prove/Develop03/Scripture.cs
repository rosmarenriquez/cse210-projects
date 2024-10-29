using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Scripture
{
    // Private Variables
    private List<Scripture> _scripture = new List<Scripture>();
    private string _fileName = "DataText.txt";
    private string _key;
    private string _text;
    public int _index; // Index used to retrieve reference
    public string _scriptureText;

    // Constructor
    public Scripture() { }

    // Load scriptures from file
    public void LoadScriptures()
    {
        List<string> readText = File.ReadAllLines(_fileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

        foreach (string line in readText)
        {
            string[] entries = line.Split(";");

            if (entries.Length >= 7)
            {
                Scripture entry = new Scripture
                {
                    _key = entries[0],
                    _text = entries[6] // Assuming that the scripture text is in the 7th column (index 6)
                };

                _scripture.Add(entry);
            }
        }
    }

    // Display all loaded scriptures
    public void ScriptureDisplay()
    {
        foreach (Scripture item in _scripture)
        {
            item.ShowScripture();
        }
    }

    // Display single scripture text
    public void ShowScripture()
    {
        Console.WriteLine($"\n{_text}");
    }

    // Get a random index for scripture selection
    public int GetRandomIndex()
    {
        var random = new Random();
        _index = random.Next(_scripture.Count);
        return _index;
    }

    // Get a random scripture's text
    public string RandomScripture()
    {
        _index = GetRandomIndex();
        return _scriptureText = _scripture[_index]._text;
    }
}