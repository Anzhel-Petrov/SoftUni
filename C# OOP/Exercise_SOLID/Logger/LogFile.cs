using Logger.Interfaces;
using System.IO;

namespace Logger
{
    public class LogFile : ILogFile
    {
        public void Write(string message)
        {
            string file = @"\\log.txt.";
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                streamWriter.Write(message);
            };
        }
    }
}
