using System.Reflection.Metadata.Ecma335;

public class MathAssignment : Assignment
{
    private string _problems;
    private string _textbookSection;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _problems = problems;
        _textbookSection = textbookSection;
    }
    public string GetHomeworkList()
    {
    return $"Section {_textbookSection} Problems {_problems}";
    }
}