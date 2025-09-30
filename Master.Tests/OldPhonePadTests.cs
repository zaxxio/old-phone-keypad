using NUnit.Framework;
using Master;
using static NUnit.Framework.Assert;

namespace Master.Tests;

[TestFixture]
public class OldPhonePadTests
{
    [Test]
    public void TestWriting()
    {
        That(OldPhonePadSolver.OldPhonePad("2#"), Is.EqualTo("A"));
        That(OldPhonePadSolver.OldPhonePad("22#"), Is.EqualTo("B"));
        That(OldPhonePadSolver.OldPhonePad("222#"), Is.EqualTo("C"));
        That(OldPhonePadSolver.OldPhonePad("3#"), Is.EqualTo("D"));
        That(OldPhonePadSolver.OldPhonePad("33#"), Is.EqualTo("E"));
        That(OldPhonePadSolver.OldPhonePad("333#"), Is.EqualTo("F"));
    }

    [Test]
    public void TestWords()
    {
        That(OldPhonePadSolver.OldPhonePad("4433555 555666#"), Is.EqualTo("HELLO"));
        That(OldPhonePadSolver.OldPhonePad("96667775553#"), Is.EqualTo("WORLD"));
        That(OldPhonePadSolver.OldPhonePad("222 2 22#"), Is.EqualTo("CAB"));
    }

    [Test]
    public void TestBackspaceOrDelete()
    {
        That(OldPhonePadSolver.OldPhonePad("227*#"), Is.EqualTo("B"));
        That(OldPhonePadSolver.OldPhonePad("2 222*22#"), Is.EqualTo("AB"));
        That(OldPhonePadSolver.OldPhonePad("2*#"), Is.EqualTo(""));
    }

    [Test]
    public void TestPause()
    {
        That(OldPhonePadSolver.OldPhonePad("2 2#"), Is.EqualTo("AA"));
        That(OldPhonePadSolver.OldPhonePad("2 22#"), Is.EqualTo("AB"));
        That(OldPhonePadSolver.OldPhonePad("22 2#"), Is.EqualTo("BA"));
    }

    [Test]
    public void TestSpecialKeys()
    {
        That(OldPhonePadSolver.OldPhonePad("0#"), Is.EqualTo(" "));
        That(OldPhonePadSolver.OldPhonePad("1#"), Is.EqualTo("&"));
        That(OldPhonePadSolver.OldPhonePad("11#"), Is.EqualTo("'"));
        That(OldPhonePadSolver.OldPhonePad("111#"), Is.EqualTo("("));
    }

    [Test]
    public void TestCyclingOrder()
    {
        That(OldPhonePadSolver.OldPhonePad("2222#"), Is.EqualTo("A")); // 4 presses on 2 = A (cycles back)
        That(OldPhonePadSolver.OldPhonePad("77777#"), Is.EqualTo("P")); // 5 presses on 7 = P (cycles back)
    }

    [Test]
    public void TestLongSequences()
    {
        Assert.That(OldPhonePadSolver.OldPhonePad("8 33 7777 8#"), Is.EqualTo("TEST"));
        Assert.That(OldPhonePadSolver.OldPhonePad("2 22 222 0 3 33 333#"), Is.EqualTo("ABC DEF"));
    }

    
}

