using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Visitor
{
    public sealed class HtmlStatisticsVisitor : IHtmlVisitor
    {
        public int ElementCount { get; private set; }
        public int TextCount { get; private set; }
        public List<string> Tags { get; } = new();

        public void VisitElement(LightElementNode node)
        {
            ElementCount++;
            Tags.Add(node.Tag.Name);
        }

        public void VisitText(LightTextNode node)
        {
            TextCount++;
        }
    }

}
