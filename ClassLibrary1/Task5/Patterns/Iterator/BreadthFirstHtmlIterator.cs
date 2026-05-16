using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Iterator
{
    public sealed class BreadthFirstHtmlIterator : IHtmlIterator
    {
        private readonly Queue<LightNode> _queue = new();

        public BreadthFirstHtmlIterator(LightNode root)
        {
            if (root != null)
            {
                _queue.Enqueue(root);
            }
        }

        public bool HasNext()
        {
            return _queue.Count > 0;
        }

        public LightNode Next()
        {
            var node = _queue.Dequeue();

            foreach (var child in node.GetChildren())
            {
                _queue.Enqueue(child);
            }

            return node;
        }
    }
}
