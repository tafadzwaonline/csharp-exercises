using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>
        {
            CreateVideo(
                "How to Build a C# Console App",
                "CodeWithAva",
                540,
                new List<Comment>
                {
                    new Comment("Liam", "This explanation was super clear."),
                    new Comment("Mia", "I finally understand classes now."),
                    new Comment("Noah", "Could you make one on inheritance next?")
                }),
            CreateVideo(
                "Top 5 Laptop Accessories for Students",
                "TechDaily",
                385,
                new List<Comment>
                {
                    new Comment("Emma", "The laptop stand recommendation was helpful."),
                    new Comment("James", "I bought the mouse you mentioned last week."),
                    new Comment("Sophia", "Great list and straight to the point."),
                    new Comment("Lucas", "Would love a budget version of this video.")
                }),
            CreateVideo(
                "Beginner Workout Routine at Home",
                "FitStart",
                720,
                new List<Comment>
                {
                    new Comment("Olivia", "Perfect routine for busy mornings."),
                    new Comment("Ethan", "The timer on screen made it easy to follow."),
                    new Comment("Charlotte", "I appreciate the low-impact options.")
                }),
            CreateVideo(
                "My Favorite Study Tips for Exam Week",
                "StudySphere",
                462,
                new List<Comment>
                {
                    new Comment("Amelia", "The Pomodoro idea worked really well for me."),
                    new Comment("Benjamin", "Thanks for sharing practical advice."),
                    new Comment("Harper", "Please make a video about note-taking too.")
                })
        };

        foreach (Video video in videos)
        {
            DisplayVideo(video);
            Console.WriteLine(new string('-', 40));
        }
    }

    static Video CreateVideo(string title, string author, int lengthInSeconds, List<Comment> comments)
    {
        Video video = new Video(title, author, lengthInSeconds);

        foreach (Comment comment in comments)
        {
            video.AddComment(comment);
        }

        return video;
    }

    static void DisplayVideo(Video video)
    {
        Console.WriteLine($"Title: {video.Title}");
        Console.WriteLine($"Author: {video.Author}");
        Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
        Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in video.Comments)
        {
            Console.WriteLine($"{comment.CommenterName}: {comment.Text}");
        }
    }
}
