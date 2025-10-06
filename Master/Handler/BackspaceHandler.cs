using Master.Context;

namespace Master.Handler;

public class BackspaceHandler : IKeyHandler
{
    public void Handle(char key, OldPhoneContext ctx)
    {
        if (ctx.Prev != '\0')
        {
            ctx.CancelPending();
            return;
        }
        if (ctx.Result.Length > 0)
            ctx.Result = ctx.Result[..^1];
    }
}