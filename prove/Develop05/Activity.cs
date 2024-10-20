using System;
using System.Threading;

abstract class Activity
{
    protected int duration; // Duration of the activity in seconds
    protected string activityName;
    protected string description;

    public void StartActivity()
    {
        ShowStartingMessage();
        PerformActivity();
        ShowEndingMessage();
    }

    protected virtual void ShowStartingMessage()
    {
        Console.WriteLine($"Starting {activityName}...");
        Console.WriteLine(description);
        Console.Write("How many seconds would you like to spend on this activity? ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3); // Short pause before starting
    }

    protected abstract void PerformActivity();

    protected virtual void ShowEndingMessage()
    {
        Console.WriteLine($"Well done! You have completed the {activityName} for {duration} seconds.");
        ShowSpinner(3); // Short pause at the end
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b");
        }
        Console.WriteLine();
    }
}
