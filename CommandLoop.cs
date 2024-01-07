using ASE_Programming_Language;
using System.Collections.Generic;
using System.Drawing;

public class CommandLoop : ICommand
{

    private string loopCountVariableName;
    private List<ICommand> commands;
    private int loopCount;
   // private List<ICommand> commands;
    private string loopVariable;
    private List<ICommand> commandList;

    public CommandLoop(string loopCountVariableName, List<ICommand> commands)
    {
        this.loopCountVariableName = loopCountVariableName;
        this.commands = commands;
    }
    public CommandLoop(int loopCount, List<ICommand> commands)
    {
        this.loopCount = loopCount;
        this.commands = commands;
    }

    /* public CommandLoop(string loopVariable, List<ICommand> commandList)
     {
         this.loopVariable = loopVariable;
         this.commandList = commandList;
     }
    */
    public void Execute(Interpreter interpreter)
    {
        // If loopCountVariableName is not null, get the count from the interpreter
        if (!string.IsNullOrEmpty(loopCountVariableName))
        {
            loopCount = interpreter.GetVariableValue(loopCountVariableName);
        }

        for (int i = 0; i < loopCount; i++)
        {
            foreach (var command in commands)
            {
                command.Execute(interpreter);
            }
        }
    }



    // Implement the GetVariableName method
    public string GetVariableName()
    {
        // Since loop commands don't necessarily have a single variable name,
        // you can return null or an empty string, or handle it differently based on your application's logic.
        return null;
    }

    // Implement the Execute method with Graphics parameter
    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        for (int i = 0; i < loopCount; i++)
        {
            foreach (var command in commands)
            {
                // Check if the command is a graphical command before using graphics
                if (command is CommandDrawCircle)
                {
                    command.Execute(interpreter, graphics);
                }
                else
                {
                    command.Execute(interpreter);
                }
            }
        }
    }
}
