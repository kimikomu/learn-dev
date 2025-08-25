using System;

class EncryptionProgram
{
    static string EncryptString(string text)
    {
        char[] encrypted = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            
            if (Char.IsLetter(c))
            {
                char caseA = Char.IsUpper(c) ? 'A' : 'a';
                
                // Console.WriteLine($"c - caseA: {c - caseA}"); Note: c - caseA gives the position of c in the alphabet (e.g., 'C' - 'A' = 2 for 'C').
                c = (char)(((c - caseA + 1) % 26) + caseA);
            }

            encrypted[i] = c;
        }
        
        return new string(encrypted);
    }
    
    static void Main()
    {
        string text = "Hello, C#! zZ";
        string encryptedText = EncryptString(text);
        Console.WriteLine("The encrypted text is: " + encryptedText);  // Should print out "The encrypted text is Ifmmp, D#! aA"
    }
}