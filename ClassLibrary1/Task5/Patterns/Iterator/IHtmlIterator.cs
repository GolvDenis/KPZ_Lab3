using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Patterns.Iterator
{
    public interface IHtmlIterator
    {
        bool HasNext();
        LightNode Next();
    }

}
