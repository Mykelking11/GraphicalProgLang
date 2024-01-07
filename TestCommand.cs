using ASE_Programming_Language;
using System.Drawing;

public class TestCommand : ICommand
{
    // Property to track the number of times Execute is called
    public int ExecutionCount { get; private set; } = 0;

    // Implementing the Execute method required by ICommand
    public void Execute(Interpreter interpreter)
    {
        // Increment the counter each time Execute is called
        ExecutionCount++;
    }

    // Implementing the GetVariableName method required by ICommand
    public string GetVariableName()
    {
        // Since this command is for testing and doesn't necessarily have a variable name,
        // return null or an empty string.
        return null;
    }

    // Implementing the Execute method with Graphics parameter
    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        // For this simple test command, we're just incrementing the count here as well.
        // In a real scenario, you'd include the logic for handling graphics.
        Execute(interpreter);
    }
}
