public class Activity
{
    protected DateTime Date;
    protected int Duration; // In minutes

    public Activity(DateTime date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} Activity ({Duration} min): Distance {GetDistance()} miles, " +
               $"Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}
