using Master.Context;

namespace Master.Handler;

/// <summary>
/// Handles pause (space) key presses.
/// Commits the current digit to the result when user pauses.
/// </summary>
public class PauseHandler : IKeyHandler
{
    // Pause commits current digit
    public void Handle(char key, OldPhoneContext ctx) => ctx.CommitPrevious();
}