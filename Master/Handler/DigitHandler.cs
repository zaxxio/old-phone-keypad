using Master.Context;

namespace Master.Handler;

/// <summary>
/// Handles digit key presses (0-9).
/// Counts repeated presses to cycle through letters on each key.
/// </summary>
public class DigitHandler : IKeyHandler
{
    public void Handle(char key, OldPhoneContext ctx)
    {
        if (key == ctx.Prev)
        {
            ctx.Count++; // Increment press count
        }
        else
        {
            ctx.CommitPrevious(); // Commit previous digit
            ctx.Prev = key;
            ctx.Count = 1;
        }
    }
}