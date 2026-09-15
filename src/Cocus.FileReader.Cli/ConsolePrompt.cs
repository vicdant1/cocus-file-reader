namespace Cocus.FileReader.Cli;

internal sealed class ConsolePrompt(TextReader input, TextWriter output)
{
    public string Ask(string question)
    {
        while (true)
        {
            output.Write($"{question} ");
            var answer = input.ReadLine() ?? throw new OperationCanceledException();

            if (!string.IsNullOrWhiteSpace(answer))
                return answer.Trim();
        }
    }

    public bool Confirm(string question)
    {
        while (true)
        {
            switch (Ask($"{question} (y/n)").ToLowerInvariant())
            {
                case "y" or "yes":
                    return true;
                case "n" or "no":
                    return false;
                default:
                    Show("Invalid answer.");
                    break;
            }
        }
    }

    public TEnum Choose<TEnum>(string question) where TEnum : struct, Enum =>
        Choose(question, Enum.GetValues<TEnum>(), option => option.ToString());

    public T Choose<T>(string question, T[] options, Func<T, string> describe)
    {
        Show(question);
        for (var i = 0; i < options.Length; i++)
            Show($"  {i + 1}) {describe(options[i])}");

        while (true)
        {
            var answer = Ask(">");
            var index = Array.FindIndex(options, option => describe(option).Equals(answer, StringComparison.OrdinalIgnoreCase));

            if (index < 0 && int.TryParse(answer, out var number))
                index = number - 1;

            if (index >= 0 && index < options.Length)
                return options[index];

            Show("Invalid option.");
        }
    }

    public void Show(string message) => output.WriteLine(message);
}
