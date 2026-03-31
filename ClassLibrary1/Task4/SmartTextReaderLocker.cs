using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1.Task4
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private readonly ISmartTextReader _reader;
        private readonly Regex _blockedPattern;

        public SmartTextReaderLocker(ISmartTextReader reader, string pattern)
        {
            _reader = reader;
            _blockedPattern = new Regex(pattern);
        }

        public char[][] ReadFile(string path)
        {
            if (_blockedPattern.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return Array.Empty<char[]>();
            }

            return _reader.ReadFile(path);
        }
    }
}
