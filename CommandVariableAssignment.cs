// Variable Assignment Command
using ASE_Programming_Language;
using System.Drawing;

public class CommandVariableAssignment : ICommand
{
    private string variableName;
    private int value;

    public CommandVariableAssignment(string variableName, int value)
    {
        this.variableName = variableName;
        this.value = value;
    }

    // Implementing the Execute method required by ICommand
    public void Execute(Interpreter interpreter)
    {
        interpreter.SetVariable(variableName, value);
    }

    // Implementing the GetVariableName method required by ICommand
    public string GetVariableName()
    {
        return variableName;
    }

    // The Execute method with Graphics parameter.
    // If this method is not relevant for this command, you can leave it empty 
    // or throw a NotImplementedException.
    public void Execute(Interpreter interpreter, Graphics graphics)
    {
        // This method might not be relevant for a variable assignment command.
        // So, you can decide how to handle it. Here's one possible way:
        Execute(interpreter); // Just call the other Execute method
    }
}


