// Circle Drawing Command
using ASE_Programming_Language;
using System;
using System.Drawing;

public class CommandDrawCircle : ICommand
{
    private string sizeArgument;
    private int x, y;

    public CommandDrawCircle(string sizeArgument, int x, int y)
    {
        this.sizeArgument = sizeArgument;
        this.x = x;
        this.y = y;
    }

    // Implementing the Execute method required by ICommand
    public void Execute(Interpreter interpreter)
    {
        // This method might not be relevant for a drawing command,
        // but it's required by the interface.
        // You can decide how to handle it. One option is to throw an exception.
        throw new NotImplementedException("Non-graphical execution not supported for this command.");
    }

    // Implementing the GetVariableName method required by ICommand
    public string GetVariableName()
    {
        return sizeArgument;
    }


    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        int size;
        if (int.TryParse(sizeArgument, out size))
        {
            // sizeArgument is a literal number, so 'size' is already assigned here
        }
        else
        {
            // sizeArgument is a variable name
            size = interpreter.GetVariableValue(sizeArgument);
          
        }

        // Drawing logic using 'size'
        graphics.DrawEllipse(Pens.Black, 0, 0, size, size);
        // Drawing logic using 'size', 'x', and 'y'
        graphics.DrawEllipse(Pens.Black, x, y, size, size);
    }


}

