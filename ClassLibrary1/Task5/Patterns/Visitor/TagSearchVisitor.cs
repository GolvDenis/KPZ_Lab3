using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Visitor
{
    public sealed class TagSearchVisitor : IHtmlVisitor
    {
        private readonly string _tagName;

        public List<LightElementNode> Matches { get; } = new();

        public TagSearchVisitor(string tagName)
        {
            _tagName = tagName;
        }

        public void VisitElement(LightElementNode node)
        {
            if (string.Equals(node.Tag.Name, _tagName, System.StringComparison.OrdinalIgnoreCase))
            {
                Matches.Add(node);
            }
        }

        public void VisitText(LightTextNode node)
        {
        }

        public LightElementNode? FirstMatch => Matches.FirstOrDefault();
    }
}
