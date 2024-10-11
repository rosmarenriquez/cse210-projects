// Program.cs
using System;
using System.Collections.Generic;

namespace VideoCommentTracker
{
    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold videos
            List<Video> videos = new List<Video>();

            // Create and add video objects
            Video video1 = new Video("Learning C#", "John Doe", 360);
            video1.AddComment(new Comment("Alice", "Great video!"));
            video1.AddComment(new Comment("Bob", "Very informative."));
            video1.AddComment(new Comment("Charlie", "I learned a lot!"));
            videos.Add(video1);

            Video video2 = new Video("Understanding Abstraction", "Jane Smith", 420);
            video2.AddComment(new Comment("Dave", "This concept is so clear now."));
            video2.AddComment(new Comment("Eva", "Thanks for the explanation."));
            videos.Add(video2);

            Video video3 = new Video("OOP Principles", "Mary Johnson", 480);
            video3.AddComment(new Comment("Frank", "Excellent breakdown of OOP."));
            video3.AddComment(new Comment("Grace", "Looking forward to more videos."));
            video3.AddComment(new Comment("Hank", "Very helpful!"));
            videos.Add(video3);

            // Display information about each video
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine(); // Just for spacing between videos
            }
        }
    }
}
