using ASE_Programming_Language;
using System.Drawing;

/// <summary>
/// Represents a command for variable assignment.
/// </summary>
public class CommandVariableAssignment : ICommand
{
    private string variableName;
    private int value;

    /// <summary>
    /// Initializes a new instance of the CommandVariableAssignment class.
    /// </summary>
    /// <param name="variableName">The name of the variable to be assigned.</param>
    /// <param name="value">The value to assign to the variable.</param>
    public CommandVariableAssignment(string variableName, int value)
    {
        this.variableName = variableName;
        this.value = value;
    }

    /// <summary>
    /// Executes the variable assignment command (required by ICommand).
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    public void Execute(Interpreter interpreter)
    {
        interpreter.SetVariable(variableName, value);
    }

    /// <summary>
    /// Gets the variable name associated with the variable assignment command (required by ICommand).
    /// </summary>
    /// <returns>The variable name.</returns>
    public string GetVariableName()
    {
        return variableName;
    }

    /// <summary>
    /// Executes the variable assignment command with graphics context.
    /// If this method is not relevant for this command, you can leave it empty
    /// or throw a NotImplementedException.
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    /// <param name="graphics">The graphics context for drawing (optional).</param>
    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        // This method might not be relevant for a variable assignment command.
        // So, you can decide how to handle it. Here's one possible way:
        Execute(interpreter); // Just call the other Execute method
    }
}
