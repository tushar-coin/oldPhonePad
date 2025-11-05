using System.Text;

class OldPhone
{
    public static char fetchCharacter (string keyPresses)
    {
        var mapping = new Dictionary<string, char>
        {
            { "2", 'A' }, { "22", 'B' }, { "222", 'C' },
            { "3", 'D' }, { "33", 'E' }, { "333", 'F' },
            { "4", 'G' }, { "44", 'H' }, { "444", 'I' },
            { "5", 'J' }, { "55", 'K' }, { "555", 'L' },
            { "6", 'M' }, { "66", 'N' }, { "666", 'O' },
            { "7", 'P' }, { "77", 'Q' }, { "777", 'R' }, { "7777", 'S' },
            { "8", 'T' }, { "88", 'U' }, { "888", 'V' },
            { "9", 'W' }, { "99", 'X' }, { "999", 'Y' }, { "9999", 'Z' }
        };
        if (mapping.TryGetValue(keyPresses, out char letter))
        {
            return letter;
        }
        else
        {
            throw new ArgumentException($"Unknown key presses: {keyPresses}");
        }
    }
    public static string OldPhonePad(string phrase)
    {
        StringBuilder textMessage = new StringBuilder();
        StringBuilder currentSequence = new StringBuilder();
        char previousChar = '~';
        foreach (char ch in phrase)
        {
            if (ch == '#')
            {
                if (currentSequence.Length > 0)
                    textMessage.Append(fetchCharacter(currentSequence.ToString()));
                currentSequence.Clear();
                return textMessage.ToString();
            }
            if (ch == '*')
            {
                if (currentSequence.Length > 0)
                    textMessage.Append(fetchCharacter(currentSequence.ToString()));
                if (textMessage.Length > 0)
                {
                    textMessage.Length--;
                }
                previousChar = '~';
                currentSequence.Clear();
                continue;
            }
            if (ch == ' ' || (ch != previousChar && previousChar != '~'))
            {
                if (currentSequence.Length > 0)
                    textMessage.Append(fetchCharacter(currentSequence.ToString()));
                    currentSequence.Clear();
            }
            if (ch == ' ')
            {
                previousChar = '~';
                continue;
            }
            currentSequence.Append(ch);
            previousChar = ch;
        }
        
        return "INVALID INPUT";  // In case there's no '#' at the end
    }
    static void Main()
    {
        try
        {
            Console.WriteLine(OldPhonePad("33#"));                // E
            Console.WriteLine(OldPhonePad("227*#"));              // B
            Console.WriteLine(OldPhonePad("4433555 555666#"));    // HELLO
            Console.WriteLine(OldPhonePad("8 88777444666*664#")); // TURING
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Fatal error in Main: {ex.Message}");
        }
    }
}