public class Swimming : Activity
{
    private int Laps;

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance() => Laps * 50 / 1000 * 0.62; // Convert laps to miles

    public override double GetSpeed() => (GetDistance() / Duration) * 60;

    public override double GetPace() => Duration / GetDistance();
}
