class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        activityName = "Breathing Activity";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        for (int time = 0; time < duration; time += 6) // Each cycle takes 6 seconds
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(3); // Simulate breathing in
            Console.WriteLine("Breathe out...");
            ShowSpinner(3); // Simulate breathing out
        }
    }
}
