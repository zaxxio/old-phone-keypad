using Master.Context;
using Master.Handler;

namespace Master;

using System;

/// <summary>
/// Converts old phone keypad input to text messages.
/// Handles digits, backspace, pause, and send operations just like old mobile phones.
/// </summary>
public class OldPhonePadSolver
{
    // Special key handlers
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
                if (c == '#') break; // Stop processing after send
            }
            else if (char.IsDigit(c))
            {
                digitHandler.Handle(c, ctx);
            }
        }
        ctx.CommitPrevious(); // Commit final character
        return ctx.Result;
    }

    public static void Main(string[] args)
    {
        
    }
}