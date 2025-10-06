using Master.Enums;

namespace Master.Context;

public class OldPhoneContext
{
    private static readonly Dictionary<KeyDigit, string> KeyMap = new()
    {
        { KeyDigit.Zero, " " },
        { KeyDigit.One, "&'(" },
        { KeyDigit.Two, "ABC" },
        { KeyDigit.Three, "DEF" },
        { KeyDigit.Four, "GHI" },
        { KeyDigit.Five, "JKL" },
        { KeyDigit.Six, "MNO" },
        { KeyDigit.Seven, "PQRS" },
        { KeyDigit.Eight, "TUV" },
        { KeyDigit.Nine, "WXYZ" }
    };

    public string Result = "";
    public char Prev = '\0';
    public int Count = 0;

    public void CommitPrevious()
    {
        if (Prev != '\0')
        {
            KeyDigit digit = (KeyDigit)(Prev - '0');
            string letters = KeyMap[digit];
            Result += letters[(Count - 1) % letters.Length];
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
