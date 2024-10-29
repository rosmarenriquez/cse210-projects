using System;
using System.Linq;
using System.Collections.Generic;

public class Word
{
    // Private Variables
    private string _words = "";
    private string _ref = "";
    private string[] _result;
    private List<int> _hidden;

    // Public Properties to access private fields if necessary
    public string Ref => _ref;

    // Constructor
    public Word()
    {
        _hidden = new List<int>();
    }

    // Method to set the scripture text
    public void GetRenderedText(Scripture scripture)
    {
        _words = scripture._scriptureText;
        _result = _words.Split(" ");
    }

    // Method to show the scripture with hidden words
    public void Show(string ref1)
    {
        _ref = ref1;
        Console.Clear();
        Console.Write("\n**** Press spacebar or enter to hide words ****");
        Console.Write("\n**** Press Q to Quit ****\n");
        Console.WriteLine($"{_ref}");
        
        for (var i = 0; i < _result.Length; i++)
        {
            var str = _result[i];
            int len = str.Length;
            string dashedLine = new String('_', len);
            Console.Write(_hidden.Contains(i) ? $"{dashedLine} " : $"{str} ");
        }
    }

    // Method to handle key presses to hide words
    public void GetReadKey()
    {
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Spacebar || input.Key == ConsoleKey.Enter)
        {
            HideNewWord();
        }
        else if (input.Key == ConsoleKey.Q)
        {
            Environment.Exit(0);
        }
    }

    // Method to hide new random words
    private void HideNewWord()
    {
        var random = new Random();
        
        while (_hidden.Count < _result.Length)
        {
            int index = random.Next(_result.Length);
            if (!_hidden.Contains(index))
            {
                _hidden.Add(index);
                break; // Exit after hiding one word to control hiding rate
            }
        }
    }

    // Method to check if all words are hidden
    public bool AreAllWordsHidden()
    {
        return _hidden.Count == _result.Length;
    }
}