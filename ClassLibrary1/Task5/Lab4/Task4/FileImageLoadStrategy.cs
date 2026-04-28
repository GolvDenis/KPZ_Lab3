using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Lab4.Task4
{
    public class FileImageLoadStrategy : IImageLoadStrategy
    {
        public string Load(string href)
        {
            if (!File.Exists(href))
            {
                return $"Файл не знайдено: {href}";
            }

            var bytes = File.ReadAllBytes(href);
            return $"Картинка завантажена з файлової системи. Розмір: {bytes.Length} байт.";
        }
    }

}
