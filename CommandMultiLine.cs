using System.Collections.Generic;
using System.Drawing;

namespace ASE_Programming_Language // Replace with your actual namespace
{
    public class CommandMultiLine : ICommand
    {
        private readonly List<ICommand> _commands;

        public CommandMultiLine(List<ICommand> commands)
        {
            _commands = commands;
        }

        public void Execute(Interpreter interpreter)
        {
            foreach (var command in _commands)
            {
                command.Execute(interpreter);
            }
        }

        public void Execute(Interpreter interpreter, Graphics graphics)
        {
            foreach (var command in _commands)
            {
                command.Execute(interpreter, graphics);
            }
        }

        public string GetVariableName()
        {
            // Since this command does not associate with a single variable, return null or an empty string
            return null;
        }
    }
}
