using ASE_Programming_Language;
using System.Drawing;

/// <summary>
/// Represents a command to draw a line.
/// </summary>
public class CommandDrawLine : ICommand
{
    private readonly Point start, end;

    /// <summary>
    /// Initializes a new instance of the CommandDrawLine class.
    /// </summary>
    /// <param name="start">The starting point of the line.</param>
    /// <param name="end">The ending point of the line.</param>
    public CommandDrawLine(Point start, Point end)
    {
        this.start = start;
        this.end = end;
    }

    /// <summary>
    /// Executes the command (required by ICommand).
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    /// <remarks>
    /// Handle non-graphical execution or throw an exception.
    /// </remarks>
    public void Execute(Interpreter interpreter)
    {
        // Handle non-graphical execution or throw an exception
    }

    /// <summary>
    /// Executes the command with graphics context.
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    /// <param name="graphics">The graphics context for drawing.</param>
    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        // Draw a line using the provided start and end points with a blue color
        graphics.DrawLine(Pens.Blue, start, end);
    }

    /// <summary>
    /// Gets the variable name associated with the command (required by ICommand).
    /// </summary>
    /// <returns>The variable name (null or an empty string if not applicable).</returns>
    public string GetVariableName()
    {
        // Return null or an empty string if this command does not use a variable
        return null;
    }
}
