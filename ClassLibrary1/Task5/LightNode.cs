using ClassLibrary1.Task5.Patterns.Visitor;

namespace ClassLibrary1.Task5
{
    public abstract class LightNode
    {
        public abstract string OuterHTML();
        public abstract string InnerHTML();

        public virtual IEnumerable<LightNode> GetChildren()
        {
            return Enumerable.Empty<LightNode>();
        }

        public virtual void OnCreated() { }
        public virtual void OnInserted() { }
        public virtual void OnRemoved() { }
        public virtual void OnTextRendered() { }

        public abstract void Accept(IHtmlVisitor visitor);
    }
}
