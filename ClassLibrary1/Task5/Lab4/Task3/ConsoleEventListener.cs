using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Lab4.Task3
{
    public class ConsoleEventListener : IEventListener
    {
        private readonly string _name;

        public ConsoleEventListener(string name)
        {
            _name = name;
        }

        public void Handle(string eventName, LightElementNode element)
        {
            Console.WriteLine($"[{_name}] Подія '{eventName}' у елемента <{element.Tag.Name}>");
        }
    }

}
