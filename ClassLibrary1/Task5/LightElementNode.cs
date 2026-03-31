using ClassLibrary1.Task6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5
{
    public class LightElementNode : LightNode
    {
        public HtmlTag Tag;
        public ElementDisplay DisplayType { get; }
        public ElementClosing ClosingType { get; }
        public List<string> CssClasses { get; } = new List<string>();
        public List<LightNode> Children { get; } = new List<LightNode>();

        public int ChildrenCount => Children.Count;

        public LightElementNode(
            HtmlTag tag,
            ElementDisplay displayType,
            ElementClosing closingType,
            IEnumerable<string>? cssClasses = null)
        {
            Tag = tag;
            DisplayType = displayType;
            ClosingType = closingType;

            if (cssClasses != null)
            {
                CssClasses.AddRange(cssClasses);
            }
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
        }

        public string GetClassesString()
        {
            return CssClasses.Count == 0 ? "" : $" class=\"{string.Join(" ", CssClasses)}\"";
        }

        public override string InnerHTML()
        {
            return string.Concat(Children.Select(child => child.OuterHTML()));
        }

        public override string OuterHTML()
        {
            string classes = GetClassesString();

            if (ClosingType == ElementClosing.Single)
            {
                return $"<{Tag.Name}{classes} />";
            }

            return $"<{Tag.Name}{classes}>{InnerHTML()}</{Tag.Name}>";
        }
    }

}
