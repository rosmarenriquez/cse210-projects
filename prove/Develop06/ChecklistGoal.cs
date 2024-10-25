using System;

public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;
    private int pointsPerCompletion;

    public ChecklistGoal(string name, int pointsPerCompletion, int targetCount, int bonusPoints) : base(name, 0)
    {
        this.pointsPerCompletion = pointsPerCompletion;
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        this.currentCount = 0;
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            currentCount++;
            Points += pointsPerCompletion;
            if (currentCount >= targetCount)
            {
                IsCompleted = true;
                Points += bonusPoints;
                Console.WriteLine($"Congrats! You've completed the checklist goal '{Name}' and earned a bonus of {bonusPoints} points. Total points: {Points}");
            }
            else
            {
                Console.WriteLine($"Progress recorded for '{Name}'. {pointsPerCompletion} points earned. Progress: {currentCount}/{targetCount}");
            }
        }
        else
        {
            Console.WriteLine($"The goal '{Name}' has already been completed.");
        }
    }

    public override string DisplayStatus()
    {
        return $"{base.DisplayStatus()} - Completed {currentCount}/{targetCount} times";
    }
}