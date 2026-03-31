using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Task1
{
    public class FileLoggerAdapter : ILogger
    {
        private readonly FileWriter _fileWriter;

        public FileLoggerAdapter(string filePath)
        {
            _fileWriter = new FileWriter(filePath);
        }

        public void Log(string message) => Write("LOG", message);
        public void Error(string message) => Write("ERROR", message);
        public void Warn(string message) => Write("WARN", message);

        private void Write(string level, string message)
        {
            _fileWriter.Write($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {level}: ");
            _fileWriter.WriteLine(message);
        }
    }
}
