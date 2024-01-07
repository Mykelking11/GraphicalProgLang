using ASE_Programming_Language;
using System.Drawing;

public class CommandDrawRectangle : ICommand
{
    private readonly int x, y, width, height;

    public CommandDrawRectangle(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public void Execute(Interpreter interpreter)
    {
        // Handle non-graphical execution or throw an exception
    }

    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        graphics.DrawRectangle(Pens.Black, x, y, width, height);
    }

    public string GetVariableName()
    {
        // Return null or an empty string if this command does not use a variable
        return null;
    }
}
