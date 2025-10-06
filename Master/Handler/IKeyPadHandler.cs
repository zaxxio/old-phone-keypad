using Master.Context;

namespace Master.Handler;

public interface IKeyHandler
{
    void Handle(char key, OldPhoneContext context);
}
