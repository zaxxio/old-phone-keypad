namespace Master;

using System;

public class OldPhonePadSolver
{
    public static string OldPhonePad(string input)
    {
        string[] KeyPad = {
            " ", "&'(", "ABC", "DEF",
            "GHI", "JKL", "MNO", "PQRS",
            "TUV", "WXYZ"
        };

        string result = "";
        char prev = '\0';
        int count = 0;

        foreach (char c in input)
        {
            if (c == '#') // Send
            {
                if (prev != '\0') 
                    result += KeyPad[prev - '0'][(count - 1) % KeyPad[prev - '0'].Length];
                break;
            }
            else if (c == '*') // Backspace
            {
                if (count > 0) { prev = '\0'; count = 0; }
                else if (result.Length > 0) result = result[..^1];
            }
            else if (c == ' ') // Pause
            {
                if (prev != '\0')
                {
                    result += KeyPad[prev - '0'][(count - 1) % KeyPad[prev - '0'].Length];
                    prev = '\0'; count = 0;
                }
            }
            else if (char.IsDigit(c)) // Digit
            {
                if (c == prev) count++;
                else
                {
                    if (prev != '\0')
                        result += KeyPad[prev - '0'][(count - 1) % KeyPad[prev - '0'].Length];
                    prev = c; count = 1;
                }
            }
        }

        return result;
    }
    
}
