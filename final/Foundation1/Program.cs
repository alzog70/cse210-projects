using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}


class CommentManager
{
    private List<Comment> _comments = new List<Comment>();

    public void AddComment(string name, string text)
    {
        _comments.Add(new Comment(name, text));
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}


class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } 
    public CommentManager CommentManager { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        CommentManager = new CommentManager();
    }
}

class VideoManager
{
    private List<Video> _videos = new List<Video>();

    public void AddVideo(Video video)
    {
        _videos.Add(video);
    }

    public void DisplayAllVideos()
    {
        foreach (var video in _videos)
        {
            Console.WriteLine($"Title: {video.Title}\nAuthor: {video.Author}\nLength: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.CommentManager.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.CommentManager.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        VideoManager videoManager = new VideoManager();

        // Create and add videos
        Video video1 = new Video("How to Code in C#", "Tech Guru", 600);
        video1.CommentManager.AddComment("Alice", "Great tutorial!");
        video1.CommentManager.AddComment("Bob", "Very helpful, thanks!");
        video1.CommentManager.AddComment("Charlie", "I learned a lot!");
        videoManager.AddVideo(video1);

        Video video2 = new Video("Gaming Highlights", "Gamer123", 900);
        video2.CommentManager.AddComment("Dave", "Awesome gameplay!");
        video2.CommentManager.AddComment("Eve", "So entertaining!");
        video2.CommentManager.AddComment("Frank", "Can't wait for the next one!");
        videoManager.AddVideo(video2);

        Video video3 = new Video("DIY Home Projects", "CraftyHands", 750);
        video3.CommentManager.AddComment("Grace", "Looks easy to follow!");
        video3.CommentManager.AddComment("Hank", "Trying this soon!");
        video3.CommentManager.AddComment("Ivy", "Love the creativity!");
        videoManager.AddVideo(video3);

        Video video4 = new Video("Travel Vlog: Japan", "Wanderlust", 1200);
        video4.CommentManager.AddComment("Jack", "Amazing places!");
        video4.CommentManager.AddComment("Kate", "I want to visit Japan now!");
        video4.CommentManager.AddComment("Leo", "Great video and editing!");
        videoManager.AddVideo(video4);

        videoManager.DisplayAllVideos();
    }
}
