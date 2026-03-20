public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            char[] hiddenCharacters = _text
                .Select(character => char.IsLetter(character) ? '_' : character)
                .ToArray();

            return new string(hiddenCharacters);
        }

        return _text;
    }
}
