using System;

class Program
{
    static void Main(string[] args)
    {
        // Clear the console and set up classes
        Console.Clear();
        Reference reference = new Reference();
        reference.LoadReference();
        Scripture scripture = new Scripture();
        scripture.LoadScriptures();
        Word word = new Word();

        Console.WriteLine("\n**** Welcome to the Scripture Memorizer App ****\n");

        int userChoice = 0;

        while (userChoice != 3)
        {
            // Display menu and get user choice
            userChoice = UserChoice();

            switch (userChoice)
            {
                case 1:
                    reference.ReferenceDisplay();
                    break;
                case 2:
                    // Select random scripture and retrieve reference
                    string scriptText = scripture.RandomScripture();
                    string refText = reference.GetReference(scripture);
                    word.GetRenderedText(scripture);

                    // Loop until all words are hidden
                    while (!word.AreAllWordsHidden())
                    {
                        word.Show(refText);
                        word.GetReadKey();
                    }
                    
                    // Final display with all words hidden
                    word.Show(refText);
                    Console.WriteLine("\nAll words are hidden. Memorization complete!");
                    break;

                case 3:
                    Console.WriteLine("\n*** Thanks for using the Scripture Memorizer App! ***\n");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }

    static int UserChoice()
    {
        // Display user options
        string choices = $@"
===========================================
Please select one of the following choices:
1. Display all available scripture references
2. Randomly select scripture to memorize
Q. Quit
===========================================
What would you like to do? ";

        Console.Write(choices);

        // Get user input and validate
        string userInput = Console.ReadLine().ToLower();
        if (userInput == "q")
        {
            return 3;
        }

        try
        {
            return int.Parse(userInput);
        }
        catch (FormatException)
        {
            return 0;
        }
    }
}