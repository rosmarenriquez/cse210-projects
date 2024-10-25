using System;

public abstract class Goal
{
    private string name;
    private int points;
    private bool isCompleted;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
        this.isCompleted = false;
    }

    public string Name { get { return name; } }
    public int Points { get { return points; } protected set { points = value; } }
    public bool IsCompleted { get { return isCompleted; } protected set { isCompleted = value; } }

    public abstract void RecordEvent();
    public virtual string DisplayStatus()
    {
        return $"{(IsCompleted ? "[X]" : "[ ]")} {Name}";
    }
}