using System;

public class EternalGoal : Goal
{
    private int pointsPerCompletion;

    public EternalGoal(string name, int pointsPerCompletion) : base(name, 0)
    {
        this.pointsPerCompletion = pointsPerCompletion;
    }

    public override void RecordEvent()
    {
        Points += pointsPerCompletion;
        Console.WriteLine($"You've recorded progress for '{Name}' and earned {pointsPerCompletion} points. Total points: {Points}");
    }
}