using ASE_Programming_Language;
using System.Drawing;

public class CommandDrawLine : ICommand
{
    private readonly Point start, end;

    public CommandDrawLine(Point start, Point end)
    {
        this.start = start;
        this.end = end;
    }

    public void Execute(Interpreter interpreter)
    {
        // Handle non-graphical execution or throw an exception
    }

    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        graphics.DrawLine(Pens.Blue, start, end);
    }

    public string GetVariableName()
    {
        // Return null or an empty string if this command does not use a variable
        return null;
    }
}
