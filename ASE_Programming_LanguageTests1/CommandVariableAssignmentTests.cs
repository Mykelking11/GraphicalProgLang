using NUnit.Framework;
using ASE_Programming_Language;
using System.Drawing; // If needed

/// <summary>
/// Test fixture for the CommandVariableAssignment class.
/// </summary>
[TestFixture]
public class CommandVariableAssignmentTests
{
    /// <summary>
    /// Test case to verify that Execute sets the variable in the interpreter.
    /// </summary>
    [Test]
    public void Execute_ShouldSetVariableInInterpreter()
    {
        // Arrange

        // Create an interpreter (or use a mock/stub if appropriate)
        var interpreter = new Interpreter();

        // Create a CommandVariableAssignment with the specified variable name and value
        var command = new CommandVariableAssignment("testVariable", 10);

        // Act

        // Execute the CommandVariableAssignment with the interpreter
        command.Execute(interpreter);

        // Assert

        // Verify that the variable in the interpreter has been set to the expected value
        int result = interpreter.GetVariableValue("testVariable"); // Assuming such a method exists
        Assert.AreEqual(10, result);
    }
}
