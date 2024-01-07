using ASE_Programming_Language;
using System.Drawing;

/// <summary>
/// Represents a command to draw a rectangle.
/// </summary>
public class CommandDrawRectangle : ICommand
{
    private readonly int x, y, width, height;

    /// <summary>
    /// Initializes a new instance of the CommandDrawRectangle class.
    /// </summary>
    /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
    /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
    /// <param name="width">The width of the rectangle.</param>
    /// <param name="height">The height of the rectangle.</param>
    public CommandDrawRectangle(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
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
        // Draw a rectangle using the provided coordinates, width, and height with a black color
        graphics.DrawRectangle(Pens.Black, x, y, width, height);
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
