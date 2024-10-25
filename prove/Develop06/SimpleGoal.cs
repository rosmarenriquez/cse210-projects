using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Congrats! You've completed the goal '{Name}' and earned {Points} points.");
        }
        else
        {
            Console.WriteLine($"The goal '{Name}' is already completed.");
        }
    }
}