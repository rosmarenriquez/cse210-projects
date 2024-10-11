// Video.cs
using System.Collections.Generic;

namespace VideoCommentTracker
{
    // Class to represent a YouTube video
    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int LengthInSeconds { get; private set; }
        private List<Comment> comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            comments = new List<Comment>();
        }

        // Method to add a comment to the video
        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        // Method to get the number of comments
        public int GetCommentCount()
        {
            return comments.Count;
        }

        // Method to display all comments
        public List<Comment> GetComments()
        {
            return comments;
        }
    }
}
