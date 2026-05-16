using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Command
{
    public sealed class RemoveChildCommand : ICommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;
        private bool _removed;

        public RemoveChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _removed = _parent.RemoveChild(_child);
        }

        public void Undo()
        {
            if (_removed)
            {
                _parent.AddChild(_child);
            }
        }
    }
}
