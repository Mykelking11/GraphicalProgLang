using ASE_Programming_Language;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Represents a command to execute a loop of other commands.
/// </summary>
public class CommandLoop : ICommand
{
    private string loopCountVariableName;
    private List<ICommand> commands;
    private int loopCount;
    // private List<ICommand> commands; // This line is commented out as it is duplicated
    private string loopVariable;
    private List<ICommand> commandList;

    /// <summary>
    /// Initializes a new instance of the CommandLoop class with a loop count variable.
    /// </summary>
    /// <param name="loopCountVariableName">The variable name containing the loop count.</param>
    /// <param name="commands">The list of commands to be executed in the loop.</param>
    public CommandLoop(string loopCountVariableName, List<ICommand> commands)
    {
        this.loopCountVariableName = loopCountVariableName;
        this.commands = commands;
    }

    /// <summary>
    /// Initializes a new instance of the CommandLoop class with a fixed loop count.
    /// </summary>
    /// <param name="loopCount">The fixed loop count.</param>
    /// <param name="commands">The list of commands to be executed in the loop.</param>
    public CommandLoop(int loopCount, List<ICommand> commands)
    {
        this.loopCount = loopCount;
        this.commands = commands;
    }

    /*
    // Uncomment this section if you plan to use a loop variable
    public CommandLoop(string loopVariable, List<ICommand> commandList)
    {
        this.loopVariable = loopVariable;
        this.commandList = commandList;
    }
    */

    /// <summary>
    /// Executes the loop command (required by ICommand).
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
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

    /// <summary>
    /// Gets the variable name associated with the loop command (required by ICommand).
    /// </summary>
    /// <returns>The variable name (null or an empty string if not applicable).</returns>
    public string GetVariableName()
    {
        // Since loop commands don't necessarily have a single variable name,
        // you can return null or an empty string, or handle it differently based on your application's logic.
        return null;
    }

    /// <summary>
    /// Executes the loop command with graphics context.
    /// </summary>
    /// <param name="interpreter">The interpreter associated with the command.</param>
    /// <param name="graphics">The graphics context for drawing (optional).</param>
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
