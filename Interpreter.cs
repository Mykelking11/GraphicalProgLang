using System;
using System.Collections.Generic;
using System.Drawing;

namespace ASE_Programming_Language
{
    /// <summary>
    /// Defines the ICommand interface for programming language commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command with the given interpreter.
        /// </summary>
        /// <param name="interpreter">The interpreter associated with the command.</param>
        void Execute(Interpreter interpreter);

        /// <summary>
        /// Gets the variable name associated with the command.
        /// </summary>
        /// <returns>The variable name (null or an empty string if not applicable).</returns>
        string GetVariableName();

        /// <summary>
        /// Executes the command with the given interpreter and graphics context.
        /// </summary>
        /// <param name="interpreter">The interpreter associated with the command.</param>
        /// <param name="graphics">The graphics context for drawing (optional).</param>
        void Execute(Interpreter interpreter, Graphics graphics);
    }

    /// <summary>
    /// Defines the Interpreter class for interpreting programming language commands.
    /// </summary>
    public class Interpreter
    {
        private Dictionary<string, int> variables = new Dictionary<string, int>();

        /// <summary>
        /// Gets the value of the specified variable from the interpreter.
        /// </summary>
        /// <param name="variableName">The name of the variable to retrieve.</param>
        /// <returns>The value of the variable.</returns>
        public int GetVariableValue(string variableName)
        {
            if (variables.ContainsKey(variableName))
            {
                return variables[variableName];
            }
            throw new Exception($"Variable '{variableName}' not defined.");
        }

        /// <summary>
        /// Sets the value of the specified variable in the interpreter.
        /// </summary>
        /// <param name="variableName">The name of the variable to set.</param>
        /// <param name="value">The value to assign to the variable.</param>
        public void SetVariable(string variableName, int value)
        {
            variables[variableName] = value;
        }

        /// <summary>
        /// Draws a circle using the provided size and Graphics object.
        /// </summary>
        /// <param name="size">The size of the circle.</param>
        /// <param name="graphics">The graphics context for drawing.</param>
        public void DrawCircle(int size, Graphics graphics)
        {
            // Draw a circle using the Graphics object
            graphics.DrawEllipse(Pens.Black, new Rectangle(0, 0, size, size));
        }
    }

    /// <summary>
    /// Represents a command for variable initialization.
    /// </summary>
    public class CommandInitialization : ICommand
    {
        private string variableName;
        private int value;

        /// <summary>
        /// Initializes a new instance of the CommandInitialization class.
        /// </summary>
        /// <param name="variableName">The name of the variable to initialize.</param>
        /// <param name="value">The value to assign to the variable.</param>
        public CommandInitialization(string variableName, int value)
        {
            this.variableName = variableName;
            this.value = value;
        }

        /// <summary>
        /// Executes the variable initialization command with the given interpreter.
        /// </summary>
        /// <param name="interpreter">The interpreter associated with the command.</param>
        public void Execute(Interpreter interpreter)
        {
            interpreter.SetVariable(variableName, value);
        }

        /// <summary>
        /// Executes the variable initialization command with the given interpreter and graphics context.
        /// If not relevant for this command, you can leave it empty or throw an exception.
        /// </summary>
        /// <param name="interpreter">The interpreter associated with the command.</param>
        /// <param name="graphics">The graphics context for drawing (optional).</param>
        public void Execute(Interpreter interpreter, Graphics graphics)
        {
            // If not relevant for this command, you can leave it empty or throw an exception
            throw new NotImplementedException("This command does not support graphical execution.");
        }

        /// <summary>
        /// Gets the variable name associated with the variable initialization command.
        /// </summary>
        /// <returns>The variable name.</returns>
        public string GetVariableName()
        {
            return variableName;
        }
    }
}
