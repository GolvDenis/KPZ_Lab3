using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Visitor
{
    public interface IHtmlVisitor
    {
        void VisitElement(LightElementNode node);
        void VisitText(LightTextNode node);
    }

}
