using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Command
{
    public sealed class RemoveClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _className;
        private bool _removed;

        public RemoveClassCommand(LightElementNode element, string className)
        {
            _element = element;
            _className = className;
        }

        public void Execute()
        {
            _removed = _element.RemoveClass(_className);
        }

        public void Undo()
        {
            if (_removed)
            {
                _element.AddClass(_className);
            }
        }
    }
}
