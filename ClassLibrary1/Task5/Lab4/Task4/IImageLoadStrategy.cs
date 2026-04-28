using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Lab4.Task4
{
    public interface IImageLoadStrategy
    {
        string Load(string href);
    }

}
