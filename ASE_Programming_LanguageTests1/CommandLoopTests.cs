using NUnit.Framework;
using ASE_Programming_Language;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Test fixture for the CommandLoop class.
/// </summary>
[TestFixture]
public class CommandLoopTests
{
    /// <summary>
    /// Test case to verify that CommandLoop executes commands multiple times.
    /// </summary>
    [Test]
    public void CommandLoop_ShouldExecuteCommandsMultipleTimes()
    {
        // Arrange

        // Create a test command
        var testCommand = new TestCommand();

        // Create a list of commands containing the test command
        var commands = new List<ICommand> { testCommand };

        // Create an interpreter
        var interpreter = new Interpreter();

        // Set the loop count to 3
        var loopCount = 3;

        // Create a CommandLoop with the specified loop count and commands
        var commandLoop = new CommandLoop(loopCount, commands); // Use int loopCount

        // Act

        // Execute the CommandLoop with the interpreter
        commandLoop.Execute(interpreter);

        // Assert

        // Verify that the test command was executed the expected number of times
        Assert.AreEqual(loopCount, testCommand.ExecutionCount);
    }
}
