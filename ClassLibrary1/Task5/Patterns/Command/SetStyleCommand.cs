using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Command
{
    public sealed class SetStyleCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _name;
        private readonly string _value;
        private string? _oldValue;
        private bool _hadOldValue;

        public SetStyleCommand(LightElementNode element, string name, string value)
        {
            _element = element;
            _name = name;
            _value = value;
        }

        public void Execute()
        {
            _hadOldValue = _element.Styles.TryGetValue(_name, out _oldValue);
            _element.SetStyle(_name, _value);
        }

        public void Undo()
        {
            if (_hadOldValue)
            {
                _element.SetStyle(_name, _oldValue ?? string.Empty);
            }
            else
            {
                _element.RemoveStyle(_name);
            }
        }
    }
}
