class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public string Title
    {
        get => _title;
        set => _title = value;
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

    public int LengthInSeconds
    {
        get => _lengthInSeconds;
        set => _lengthInSeconds = value;
    }

    public List<Comment> Comments
    {
        get => _comments;
        set => _comments = value;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}
