public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
    }

    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words
            .Where(word => !word.IsHidden())
            .ToList();

        if (visibleWords.Count == 0)
        {
            return;
        }

        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = Random.Shared.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {scriptureText}";
    }
}
