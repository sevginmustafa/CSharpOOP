using System;
using System.IO;
using System.Linq;

namespace _01Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";

        public long Size => File.ReadAllText(LogFilePath).Where(char.IsLetter).Sum(x => x);

        public void Write(string message)
        {
            File.AppendAllText(LogFilePath, message + Environment.NewLine);
        }
    }
}
