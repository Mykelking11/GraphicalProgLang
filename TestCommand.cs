using ASE_Programming_Language;
using System.Drawing;

/// <summary>
/// Represents a test command for testing purposes.
/// </summary>
public class TestCommand : ICommand
{
    // Property to track the number of times Execute is called
    public int ExecutionCount { get; private set; } = 0;

    /// <summary>
    /// Executes the test command with the given interpreter.
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    public void Execute(Interpreter interpreter)
    {
        // Increment the counter each time Execute is called
        ExecutionCount++;
    }

    /// <summary>
    /// Gets the variable name associated with the test command.
    /// </summary>
    /// <returns>The variable name (null or an empty string if not applicable).</returns>
    public string GetVariableName()
    {
        // Since this command is for testing and doesn't necessarily have a variable name,
        // return null or an empty string.
        return null;
    }

    /// <summary>
    /// Executes the test command with the given interpreter and graphics context.
    /// For this simple test command, the logic involves incrementing the execution count.
    /// In a real scenario, you'd include the logic for handling graphics.
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    /// <param name="graphics">The graphics context for drawing (optional).</param>
    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        // For this simple test command, we're just incrementing the count here as well.
        // In a real scenario, you'd include the logic for handling graphics.
        Execute(interpreter);
    }
}
