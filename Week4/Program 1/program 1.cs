using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Programming Basics", "Mosh Hamedani", 7200);
        video1.AddComment(new Comment("Alice", "Great introduction to C#! Very clear explanations."));
        video1.AddComment(new Comment("Bob", "I learned a lot from this video. Thanks, Mosh!"));
        video1.AddComment(new Comment("Charlie", "Can you make a video on advanced topics next?"));
        videos.Add(video1);

        Video video2 = new Video("Understanding Asynchronous C#", "Microsoft Learn", 3600);
        video2.AddComment(new Comment("David", "Async/await finally makes sense!"));
        video2.AddComment(new Comment("Eve", "Excellent examples, very helpful."));
        video2.AddComment(new Comment("Frank", "This helped me fix a bug in my application."));
        video2.AddComment(new Comment("Grace", "Could use a bit more detail on error handling in async methods."));
        videos.Add(video2);

        Video video3 = new Video("Building REST APIs with ASP.NET Core", "Scott Hanselman", 5400);
        video3.AddComment(new Comment("Heidi", "Fantastic walk-through of API development."));
        video3.AddComment(new Comment("Ivan", "Scott always delivers clear and concise content."));
        video3.AddComment(new Comment("Judy", "What about authentication and authorization?"));
        videos.Add(video3);

        Video video4 = new Video("Introduction to .NET MAUI", "Gerald Versluis", 2700);
        video4.AddComment(new Comment("Kevin", "MAUI looks promising! Excited to try it."));
        video4.AddComment(new Comment("Liam", "Good overview, looking forward to more deep dives."));
        video4.AddComment(new Comment("Mia", "Does it support Blazor Hybrid?"));
        videos.Add(video4);

        Console.WriteLine("--- YouTube Video Information ---");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}