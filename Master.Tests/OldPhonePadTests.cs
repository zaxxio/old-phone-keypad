using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Master.Tests;

[TestFixture]
public class OldPhonePadTests
{
    private OldPhonePadSolver solver;

    [OneTimeSetUp]
    public void Setup()
    {
        solver = new OldPhonePadSolver();
    }

    [Test]
    public void TestWriting()
    {
        That(solver.OldPhonePad("2#"), Is.EqualTo("A"));
        That(solver.OldPhonePad("22#"), Is.EqualTo("B"));
        That(solver.OldPhonePad("222#"), Is.EqualTo("C"));
        That(solver.OldPhonePad("3#"), Is.EqualTo("D"));
        That(solver.OldPhonePad("33#"), Is.EqualTo("E"));
        That(solver.OldPhonePad("333#"), Is.EqualTo("F"));
    }

    [Test]
    public void TestWords()
    {
        That(solver.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));
        That(solver.OldPhonePad("96667775553#"), Is.EqualTo("WORLD"));
        That(solver.OldPhonePad("222 2 22#"), Is.EqualTo("CAB"));
    }

    [Test]
    public void TestBackspaceOrDelete()
    {
        That(solver.OldPhonePad("227*#"), Is.EqualTo("B"));
        That(solver.OldPhonePad("2 222*22#"), Is.EqualTo("AB"));
        That(solver.OldPhonePad("2*#"), Is.EqualTo(""));
        That(solver.OldPhonePad("22**#"), Is.EqualTo("")); // multiple backspaces
    }

    [Test]
    public void TestPause()
    {
        That(solver.OldPhonePad("2 2#"), Is.EqualTo("AA"));
        That(solver.OldPhonePad("2 22#"), Is.EqualTo("AB"));
        That(solver.OldPhonePad("22 2#"), Is.EqualTo("BA"));
        That(solver.OldPhonePad("33 33 33#"), Is.EqualTo("EEE"));
    }

    [Test]
    public void TestSpecialKeys()
    {
        That(solver.OldPhonePad("0#"), Is.EqualTo(" "));
        That(solver.OldPhonePad("1#"), Is.EqualTo("&"));
        That(solver.OldPhonePad("11#"), Is.EqualTo("'"));
        That(solver.OldPhonePad("111#"), Is.EqualTo("("));
    }

    [Test]
    public void TestCyclingOrder()
    {
        That(solver.OldPhonePad("2222#"), Is.EqualTo("A")); // 4 presses on 2 = A
        That(solver.OldPhonePad("77777#"), Is.EqualTo("P")); // 5 presses on 7 = P
        That(solver.OldPhonePad("99999#"), Is.EqualTo("W")); // cycles back
    }

    [Test]
    public void TestLongSequences()
    {
        That(solver.OldPhonePad("8 33 7777 8#"), Is.EqualTo("TEST"));
        That(solver.OldPhonePad("2 22 222 0 3 33 333#"), Is.EqualTo("ABC DEF"));
        That(solver.OldPhonePad("4 666 666 3 0 6 33#"), Is.EqualTo("GOOD ME"));
    }

    [Test]
    public void TestEmptyAndNoSend()
    {
        That(solver.OldPhonePad(""), Is.EqualTo(""));
        That(solver.OldPhonePad("222"),
            Is.EqualTo("C")); // no '#', should still commit last char if your solver supports it
    }

    [Test]
    public void TestInvalidCharactersIgnored()
    {
        That(solver.OldPhonePad("2a3b#"), Is.EqualTo("AD")); // non-digit ignored
        That(solver.OldPhonePad("44@33#"), Is.EqualTo("HE"));
    }

    [Test]
    public void TestDoubleSend()
    {
        That(solver.OldPhonePad("22##"), Is.EqualTo("B")); // early stop at first '#'
    }

    [Test]
    public void TestLeadingAndTrailingSpaces()
    {
        That(solver.OldPhonePad(" 2 2#"), Is.EqualTo("AA"));
        That(solver.OldPhonePad("22  2#"), Is.EqualTo("BA"));
    }

    [Test]
    public void TestMultipleBackspacesInLongSequence()
    {
        That(solver.OldPhonePad("4433555 555666* 6#"), Is.EqualTo("HELLM"));
        That(solver.OldPhonePad("4433555 555666* 666#"), Is.EqualTo("HELLO"));
    }

    [Test]
    public void TestRapidAlternatingKeys()
    {
        That(solver.OldPhonePad("2 3 33#"), Is.EqualTo("ADE"));
        That(solver.OldPhonePad("222333444555666777888999#"), Is.EqualTo("CFILORVY"));
    }

    [Test]
    public void TestOnlyBackspaces()
    {
        That(solver.OldPhonePad("****#"), Is.EqualTo(""));
    }
}