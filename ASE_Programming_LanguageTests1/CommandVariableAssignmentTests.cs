using NUnit.Framework;
using ASE_Programming_Language;
using System.Drawing; // If needed

[TestFixture]
public class CommandVariableAssignmentTests
{
    [Test]
    public void Execute_ShouldSetVariableInInterpreter()
    {
        // Arrange
        var interpreter = new Interpreter(); // Or use a mock/stub if appropriate
        var command = new CommandVariableAssignment("testVariable", 10);

        // Act
        command.Execute(interpreter);

        // Assert
        int result = interpreter.GetVariableValue("testVariable"); // Assuming such a method exists
        Assert.AreEqual(10, result);
    }

}
