using NUnit.Framework;
using ASE_Programming_Language;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework.Internal.Commands;

[TestFixture]
public class CommandLoopTests
{
    [Test]
    public void CommandLoop_ShouldExecuteCommandsMultipleTimes()
    {
        // Arrange
        var testCommand = new TestCommand();
        var commands = new List<ICommand> { testCommand };
        var interpreter = new Interpreter();
        var loopCount = 3;
        var commandLoop = new CommandLoop(loopCount, commands); // Use int loopCount

        // Act
        commandLoop.Execute(interpreter);

        // Assert
        Assert.AreEqual(loopCount, testCommand.ExecutionCount);
    }

}
