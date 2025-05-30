using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; } = new List<Comment>();

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public List<Comment> GetComments()
    {
        return new List<Comment>(Comments);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video
        {
            Title = "C# Tutorial for Beginners",
            Author = "Programming Master",
            Length = 600
        };
        video1.AddComment(new Comment { CommenterName = "User1", CommentText = "Great tutorial!" });
        video1.AddComment(new Comment { CommenterName = "User2", CommentText = "Very helpful, thanks!" });
        video1.AddComment(new Comment { CommenterName = "User3", CommentText = "Could you make one about OOP?" });
        videos.Add(video1);

        Video video2 = new Video
        {
            Title = "ASP.NET Core Crash Course",
            Author = "Web Dev Pro",
            Length = 1200
        };
        video2.AddComment(new Comment { CommenterName = "Dev1", CommentText = "Excellent content" });
        video2.AddComment(new Comment { CommenterName = "Dev2", CommentText = "When is the next part coming?" });
        video2.AddComment(new Comment { CommenterName = "Dev3", CommentText = "Clear explanations" });
        video2.AddComment(new Comment { CommenterName = "Dev4", CommentText = "Loved the examples" });
        videos.Add(video2);

        Video video3 = new Video
        {
            Title = "Learning LINQ in 10 Minutes",
            Author = "Code Ninja",
            Length = 600
        };
        video3.AddComment(new Comment { CommenterName = "Student1", CommentText = "Mind blown!" });
        video3.AddComment(new Comment { CommenterName = "Student2", CommentText = "This changed how I code" });
        video3.AddComment(new Comment { CommenterName = "Student3", CommentText = "Short and sweet" });
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}