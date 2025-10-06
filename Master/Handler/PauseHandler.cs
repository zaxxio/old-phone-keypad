using Master.Context;

namespace Master.Handler;

public class PauseHandler : IKeyHandler
{
    public void Handle(char key, OldPhoneContext ctx) => ctx.CommitPrevious();
}