using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Command
{
    public sealed class RemoveStyleCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _name;
        private string? _oldValue;
        private bool _removed;

        public RemoveStyleCommand(LightElementNode element, string name)
        {
            _element = element;
            _name = name;
        }

        public void Execute()
        {
            _removed = _element.Styles.TryGetValue(_name, out _oldValue) && _element.RemoveStyle(_name);
        }

        public void Undo()
        {
            if (_removed)
            {
                _element.SetStyle(_name, _oldValue ?? string.Empty);
            }
        }
    }
}
