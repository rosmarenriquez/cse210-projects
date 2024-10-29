using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Reference
{
    // Private Variables
    private List<Reference> _reference = new List<Reference>();
    private string _fileName = "DataText.txt";
    private string _key;
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd; // Nullable to handle single verses

    // Constructors
    public Reference() { }

    // Constructor for single-verse references
    public Reference(string book, int chapter, int verseStart)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = null;
    }

    // Constructor for multi-verse references
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    // Method to load references from file
    public void LoadReference()
    {
        List<string> readText = File.ReadAllLines(_fileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

        foreach (string line in readText)
        {
            string[] entries = line.Split(";");

            if (entries.Length >= 5)
            {
                var book = entries[1];
                var chapter = int.Parse(entries[2]);
                var verseStart = int.Parse(entries[3]);
                var verseEnd = int.Parse(entries[4]);

                Reference entry = verseEnd == 0 
                    ? new Reference(book, chapter, verseStart)
                    : new Reference(book, chapter, verseStart, verseEnd);

                entry._key = entries[0];
                _reference.Add(entry);
            }
        }
    }

    // Method to display all references
    public void ReferenceDisplay()
    {
        foreach (Reference item in _reference)
        {
            if (item._verseEnd.HasValue)
            {
                item.DisplayMultiVerseReference();
            }
            else
            {
                item.DisplaySingleVerseReference();
            }
        }
    }

    // Retrieve formatted reference string
    public string GetReference(Scripture scripture)
    {
        var index = scripture._index;
        var refi = _reference[index];
        
        return refi._verseEnd.HasValue 
            ? $"\n{refi._book} {refi._chapter}:{refi._verseStart}-{refi._verseEnd}"
            : $"\n{refi._book} {refi._chapter}:{refi._verseStart}";
    }

    // Display methods for single and multi-verse references
    private void DisplaySingleVerseReference()
    {
        Console.WriteLine($"\n{_book} {_chapter}:{_verseStart}");
    }

    private void DisplayMultiVerseReference()
    {
        Console.WriteLine($"\n{_book} {_chapter}:{_verseStart}-{_verseEnd}");
    }
}