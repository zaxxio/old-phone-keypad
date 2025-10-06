using Master.Enums;

namespace Master.Context;

/// <summary>
/// Keeps track of the current text conversion state.
/// Stores the result, previous digit, and press count for cycling through letters.
/// </summary>
public class OldPhoneContext
{
    // Keypad to letters mapping
    private static readonly Dictionary<KeyPad, string> KeyMap = new()
    {
        { KeyPad.Zero, " " },
        { KeyPad.One, "&'(" },
        { KeyPad.Two, "ABC" },
        { KeyPad.Three, "DEF" },
        { KeyPad.Four, "GHI" },
        { KeyPad.Five, "JKL" },
        { KeyPad.Six, "MNO" },
        { KeyPad.Seven, "PQRS" },
        { KeyPad.Eight, "TUV" },
        { KeyPad.Nine, "WXYZ" }
    };

    public string Result = "";
    public char Prev = '\0'; // Previous digit
    public int Count = 0; // Press count

    public void CommitPrevious()
    {
        if (Prev != '\0')
        {
            KeyPad pad = (KeyPad)(Prev - '0');
            string letters = KeyMap[pad];
            Result += letters[(Count - 1) % letters.Length]; // Cycle through letters
            Prev = '\0';
            Count = 0;
        }
    }
    
    public void CancelPending()
    {
        Prev = '\0';
        Count = 0;
    }
}
