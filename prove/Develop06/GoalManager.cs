using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GoalManager
{
    private List<Goal> goals;
    private int totalScore;

    public GoalManager()
    {
        goals = new List<Goal>();
        totalScore = 0;
    }

    public void DisplayMenu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Eternal Quest Program ---");
            Console.WriteLine("1. Create a New Goal");
            Console.WriteLine("2. Record an Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    DisplayGoals();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\n--- Create a New Goal ---");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a goal type: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        switch (goalType)
        {
            case "1":
                Console.Write("Enter points for completion: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, simplePoints));
                Console.WriteLine($"Simple Goal '{name}' created.");
                break;

            case "2":
                Console.Write("Enter points per completion: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, eternalPoints));
                Console.WriteLine($"Eternal Goal '{name}' created.");
                break;

            case "3":
                Console.Write("Enter points per completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter target count for completion: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing the checklist: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, checklistPoints, targetCount, bonusPoints));
                Console.WriteLine($"Checklist Goal '{name}' created.");
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private void RecordEvent()
    {
        DisplayGoals();
        Console.Write("Select the goal number to record an event: ");
        int goalIndex = int.Parse(Console.ReadLine());

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].RecordEvent();
            totalScore += goals[goalIndex].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    private void DisplayGoals()
    {
        Console.WriteLine("\n--- Goals ---");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i}. {goals[i].DisplayStatus()}");
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"\nTotal Score: {totalScore} points");
    }

    private void SaveGoals()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var saveData = new SaveData { Goals = goals, TotalScore = totalScore };

            string jsonString = JsonSerializer.Serialize(saveData, options);
            File.WriteAllText("goals.json", jsonString);

            Console.WriteLine("Goals and score have been saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        try
        {
            if (File.Exists("goals.json"))
            {
                string jsonString = File.ReadAllText("goals.json");
                var saveData = JsonSerializer.Deserialize<SaveData>(jsonString);

                goals = saveData.Goals ?? new List<Goal>();
                totalScore = saveData.TotalScore;

                Console.WriteLine("Goals and score have been loaded.");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}