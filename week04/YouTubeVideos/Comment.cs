class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string CommenterName
    {
        get => _commenterName;
        set => _commenterName = value;
    }

    public string Text
    {
        get => _text;
        set => _text = value;
    }
}
