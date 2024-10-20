class GratitudeActivity : Activity
{
    public GratitudeActivity()
    {
        activityName = "Gratitude Activity";
        description = "This activity will help you focus on the positive by listing things you are grateful for. Take a moment to reflect on the good in your life.";
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Start listing things you're grateful for:");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} things you're grateful for!");
    }
}
