using Master.Context;

namespace Master.Handler;

public class DigitHandler : IKeyHandler
{
    public void Handle(char key, OldPhoneContext ctx)
    {
        if (key == ctx.Prev)
        {
            ctx.Count++;
        }
        else
        {
            ctx.CommitPrevious();
            ctx.Prev = key;
            ctx.Count = 1;
        }
    }
}