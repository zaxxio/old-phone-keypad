using Master.Context;
using Master.Handler;

namespace Master;

using System;

public class OldPhonePadSolver
{
    private readonly Dictionary<char, IKeyHandler> _handlers = new()
    {
        { '*', new BackspaceHandler() },
        { ' ', new PauseHandler() },
        { '#', new SendHandler() }
    };

    public string OldPhonePad(string input)
    {
        var ctx = new OldPhoneContext();
        var digitHandler = new DigitHandler();

        foreach (char c in input)
        {
            if (_handlers.TryGetValue(c, out var handler))
            {
                handler.Handle(c, ctx);
                if (c == '#') break; 
            }
            else if (char.IsDigit(c))
            {
                digitHandler.Handle(c, ctx);
            }
        }
        ctx.CommitPrevious();
        return ctx.Result;
    }

    public static void Main(string[] args)
    {
        var solver = new OldPhonePadSolver();
        Console.WriteLine(solver.OldPhonePad("4433555 555666#")); // HELLO
        Console.WriteLine(solver.OldPhonePad("8 88777444666*664#")); // TONE
    }
}