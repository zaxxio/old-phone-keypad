using Master.Context;

namespace Master.Handler;

/// <summary>
/// Defines how different keys should be handled during text conversion.
/// Each key type has its own behavior for processing input.
/// </summary>
public interface IKeyHandler
{
    void Handle(char key, OldPhoneContext context);
}
