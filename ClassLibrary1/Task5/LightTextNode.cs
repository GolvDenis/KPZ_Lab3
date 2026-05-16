using ClassLibrary1.Task5.Patterns.Visitor;

namespace ClassLibrary1.Task5
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            Text = text;
            OnCreated();
        }

        public override void Accept(IHtmlVisitor visitor)
        {
            visitor.VisitText(this);
        }

        public override string OuterHTML()
        {
            OnTextRendered();
            return Text;
        }

        public override string InnerHTML()
        {
            return Text;
        }
    }
}
