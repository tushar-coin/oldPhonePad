using System;
using System.Text;
using System.Collections.Generic;

class OldPhone
{
    public static string OldPhonePad(string phrase)
    {
        var mapping = new Dictionary<string, char>
        {
            // make these mapping string to char
            { "2", 'A' }, { "22", 'B' }, { "222", 'C' },
            { "3", 'D' }, { "33", 'E' }, { "333", 'F' },
            { "4", 'G' }, { "44", 'H' }, { "444", 'I' },
            { "5", 'J' }, { "55", 'K' }, { "555", 'L' },
            { "6", 'M' }, { "66", 'N' }, { "666", 'O' },
            { "7", 'P' }, { "77", 'Q' }, { "777", 'R' }, { "7777", 'S' },
            { "8", 'T' }, { "88", 'U' }, { "888", 'V' },
            { "9", 'W' }, { "99", 'X' }, { "999", 'Y' }, { "9999", 'Z' }
        };
        StringBuilder textMessage = new StringBuilder();
        StringBuilder currentSequence = new StringBuilder();
        char previousChar = '~'; 
        foreach (char ch in phrase)
        {
            if (ch == '#')
            {
                if(currentSequence.ToString() != " ")
                textMessage.Append(mapping[currentSequence.ToString()]);
                currentSequence.Clear();
                return textMessage.ToString();
            }
            if (ch == ' ' || (ch != previousChar && previousChar != '~'))
            {
                if(currentSequence.ToString() != " ")
                textMessage.Append(mapping[currentSequence.ToString()]);
                currentSequence.Clear();
            }
            if (ch == '*')
            {
                if (textMessage.Length > 0)
                {
                    textMessage.Length--;
                }
                previousChar = '~';
                continue;
            }  
            currentSequence.Append(ch);
            previousChar = ch;
        }
        return "";
    }
    static void Main()
    {
        Console.WriteLine(OldPhonePad("8 88777444666*664#"));
    }
}