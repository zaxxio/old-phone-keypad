using Master.Context;

namespace Master.Handler;

/// <summary>
/// Handles send (#) key presses.
/// Commits the current digit and signals end of input.
/// </summary>
public class SendHandler : IKeyHandler
{
    // Send commits current digit
    public void Handle(char key, OldPhoneContext ctx) => ctx.CommitPrevious();
}