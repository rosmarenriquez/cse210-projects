class MindfulnessApp
{
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Mindfulness App.");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity"); // Added Gratitude Activity
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => new GratitudeActivity(), // Added Gratitude Activity
                "5" => null,
                _ => null
            };

            if (activity == null)
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            activity.StartActivity();
        }
    }
}
