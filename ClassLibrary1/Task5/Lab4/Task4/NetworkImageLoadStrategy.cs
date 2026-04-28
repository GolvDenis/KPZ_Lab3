using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task5.Lab4.Task4
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public string Load(string href)
        {
            try
            {
                using var client = new HttpClient();
                var bytes = client.GetByteArrayAsync(href).GetAwaiter().GetResult();
                return $"Картинка завантажена з мережі. Розмір: {bytes.Length} байт.";
            }
            catch (Exception ex)
            {
                return $"Помилка завантаження з мережі: {ex.Message}";
            }
        }
    }

}
