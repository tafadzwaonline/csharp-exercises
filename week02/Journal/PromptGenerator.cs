using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small win I want to remember from today?",
        "What challenged me today, and how did I respond?"
    };

    private readonly Random _random = new Random();
    private readonly List<string> _unusedPrompts = new List<string>();

    public string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts.AddRange(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return prompt;
    }
}
