using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Command
{
    public sealed class CommandInvoker
    {
        private readonly Stack<ICommand> _history = new();

        public void Execute(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public bool UndoLast()
        {
            if (_history.Count == 0)
            {
                return false;
            }

            var command = _history.Pop();
            command.Undo();
            return true;
        }
    }
}
