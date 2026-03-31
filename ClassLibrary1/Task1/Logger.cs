using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task1
{
    public class Logger : ILogger
    {
        public void Log(string message) => WriteColored($"[LOG] {message}", ConsoleColor.Green);
        public void Error(string message) => WriteColored($"[ERROR] {message}", ConsoleColor.Red);
        public void Warn(string message) => WriteColored($"[WARN] {message}", ConsoleColor.DarkYellow);

        private void WriteColored(string message, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }
    }

}
