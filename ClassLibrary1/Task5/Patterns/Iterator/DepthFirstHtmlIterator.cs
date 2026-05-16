using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Iterator
{
    public sealed class DepthFirstHtmlIterator : IHtmlIterator
    {
        private readonly Stack<LightNode> _stack = new();

        public DepthFirstHtmlIterator(LightNode root)
        {
            if (root != null)
            {
                _stack.Push(root);
            }
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        public LightNode Next()
        {
            var node = _stack.Pop();
            var children = node.GetChildren().ToList();

            for (int i = children.Count - 1; i >= 0; i--)
            {
                _stack.Push(children[i]);
            }

            return node;
        }
    }

}
