using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Visitor
{
    public sealed class CssClassCollectorVisitor : IHtmlVisitor
    {
        public HashSet<string> Classes { get; } = new();

        public void VisitElement(LightElementNode node)
        {
            foreach (var cssClass in node.CssClasses)
            {
                Classes.Add(cssClass);
            }
        }

        public void VisitText(LightTextNode node)
        {
        }
    }
}
