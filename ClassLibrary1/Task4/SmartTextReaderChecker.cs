using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task4
{
    public class SmartTextReaderChecker : ISmartTextReader
    {
        private readonly ISmartTextReader _reader;

        public SmartTextReaderChecker(ISmartTextReader reader)
        {
            _reader = reader;
        }

        public char[][] ReadFile(string path)
        {
            Console.WriteLine($"[Checker] Opening file: {path}");

            try
            {
                var data = _reader.ReadFile(path);

                Console.WriteLine("[Checker] File read successfully.");
                Console.WriteLine($"[Checker] Lines: {data.Length}");
                Console.WriteLine($"[Checker] Symbols: {data.Sum(line => line.Length)}");

                return data;
            }
            finally
            {
                Console.WriteLine($"[Checker] Closing file: {path}");
            }
        }
    }

}
