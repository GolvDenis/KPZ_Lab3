namespace ClassLibrary1.Task5
{
    public class LightTextNode : LightNode
    {
        public string Text { get; }

        public LightTextNode(string text)
        {
            Text = text;
        }

        public override string OuterHTML()
        {
            return Text;
        }

        public override string InnerHTML()
        {
            return Text;
        }
    }
}
