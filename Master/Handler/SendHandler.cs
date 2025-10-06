using Master.Context;

namespace Master.Handler;

public class SendHandler : IKeyHandler
{
    public void Handle(char key, OldPhoneContext ctx) => ctx.CommitPrevious();
}