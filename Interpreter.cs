using System;
using System.Collections.Generic;
using System.Drawing;

namespace ASE_Programming_Language
{
    // Define the ICommand interface
    public interface ICommand
    {
        void Execute(Interpreter interpreter);
        string GetVariableName();
        void Execute(Interpreter interpreter, Graphics graphics);
    }

    // Define the Interpreter class
    public class Interpreter
    {
        private Dictionary<string, int> variables = new Dictionary<string, int>();

        public int GetVariableValue(string variableName)
        {
            if (variables.ContainsKey(variableName))
            {
                return variables[variableName];
            }
            throw new Exception($"Variable '{variableName}' not defined.");
        }

        public void SetVariable(string variableName, int value)
        {
            variables[variableName] = value;
        }

        // Method to execute a drawing command
        public void DrawCircle(int size, Graphics graphics)
        {
            // Draw a circle using the Graphics object
            graphics.DrawEllipse(Pens.Black, new Rectangle(0, 0, size, size));
        }
    }


    // Define the CommandInitialization class
    public class CommandInitialization : ICommand
    {
        private string variableName;
        private int value;

        public CommandInitialization(string variableName, int value)
        {
            this.variableName = variableName;
            this.value = value;
        }

        public void Execute(Interpreter interpreter)
        {
            interpreter.SetVariable(variableName, value);
            
        }

        // Implement the Execute method with Graphics parameter
        public void Execute(Interpreter interpreter, Graphics graphics)
        {
            // If not relevant for this command, you can leave it empty or throw an exception
            throw new NotImplementedException("This command does not support graphical execution.");
        }

        public string GetVariableName()
        {
            return variableName;
        }

    }

}
