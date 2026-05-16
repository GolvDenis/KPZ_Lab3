using ClassLibrary1.Task5.Lab4.Task3;
using ClassLibrary1.Task5.Patterns.State;
using ClassLibrary1.Task5.Patterns.Visitor;
using ClassLibrary1.Task6;

namespace ClassLibrary1.Task5
{
    public class LightElementNode : LightNode
    {
        public HtmlTag Tag { get; }
        public ElementDisplay DisplayType { get; }
        public ElementClosing ClosingType { get; }
        public List<string> CssClasses { get; } = new();
        public Dictionary<string, string> Styles { get; } = new();
        public List<LightNode> Children { get; } = new();

        private readonly Dictionary<string, List<IEventListener>> _listeners = new();

        public ILightNodeState State { get; private set; }

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

            State = new CreatedState();
        }

        public void AddChild(LightNode child)
        {
            Children.Add(child);
            State = new InsertedState();
        }

        public bool RemoveChild(LightNode child)
        {
            var removed = Children.Remove(child);

            if (removed)
            {
                State = new RemovedState();
            }

            return removed;
        }

        public void AddClass(string cssClass)
        {
            if (string.IsNullOrWhiteSpace(cssClass))
            {
                return;
            }

            if (!CssClasses.Contains(cssClass))
            {
                CssClasses.Add(cssClass);
            }
        }

        public bool RemoveClass(string cssClass)
        {
            return CssClasses.Remove(cssClass);
        }

        public void SetStyle(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            Styles[name] = value ?? string.Empty;
        }

        public bool RemoveStyle(string name)
        {
            return Styles.Remove(name);
        }

        public void AddEventListener(string eventName, IEventListener listener)
        {
            if (!_listeners.ContainsKey(eventName))
            {
                _listeners[eventName] = new List<IEventListener>();
            }

            _listeners[eventName].Add(listener);
        }

        public void RemoveEventListener(string eventName, IEventListener listener)
        {
            if (_listeners.ContainsKey(eventName))
            {
                _listeners[eventName].Remove(listener);
            }
        }

        public void TriggerEvent(string eventName)
        {
            if (_listeners.ContainsKey(eventName))
            {
                foreach (var listener in _listeners[eventName])
                {
                    listener.Handle(eventName, this);
                }
            }
            else
            {
                Console.WriteLine($"Для <{Tag.Name}> немає підписників на '{eventName}'.");
            }
        }

        public string GetClassesString()
        {
            return CssClasses.Count == 0 ? string.Empty : $" class=\"{string.Join(" ", CssClasses)}\"";
        }

        public string GetStylesString()
        {
            if (Styles.Count == 0)
            {
                return string.Empty;
            }

            return $" style=\"{string.Join("; ", Styles.Select(x => $"{x.Key}: {x.Value}"))}\"";
        }

        public override IEnumerable<LightNode> GetChildren()
        {
            return Children;
        }

        public override void Accept(Patterns.Visitor.IHtmlVisitor visitor)
        {
            visitor.VisitElement(this);

            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }

        public override string InnerHTML()
        {
            return string.Concat(Children.Select(child => child.OuterHTML()));
        }

        public override string OuterHTML()
        {
            State = new RenderedState();

            string classes = GetClassesString();
            string styles = GetStylesString();

            if (ClosingType == ElementClosing.Single)
            {
                return $"<{Tag.Name}{classes}{styles} />";
            }

            return $"<{Tag.Name}{classes}{styles}>{InnerHTML()}</{Tag.Name}>";
        }
    }
}
