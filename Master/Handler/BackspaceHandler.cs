using Master.Context;

namespace Master.Handler;

/// <summary>
/// Handles backspace (*) key presses.
/// Cancels pending digits or removes the last character from the result.
/// </summary>
public class BackspaceHandler : IKeyHandler
{
    public void Handle(char key, OldPhoneContext ctx)
    {
        if (ctx.Prev != '\0')
        {
            ctx.CancelPending(); // Cancel pending digit
            return;
        }
        if (ctx.Result.Length > 0)
            ctx.Result = ctx.Result[..^1]; // Remove last character
    }
}