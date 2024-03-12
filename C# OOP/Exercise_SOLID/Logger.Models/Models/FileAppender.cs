using Logger.Interfaces;
using System;
using System.IO;

namespace Logger
{
    public class FileAppender : IAppender
    {
        private readonly ILayout _layout;
        public string FilePath { get; set; } = $"..\\..\\..\\{DateTime.Now:yyyyMMddhhmmss}.txt";

        public FileAppender(ILayout layout)
        {
            _layout = layout;
        }

        public FileAppender(ILayout layout, string filePath)
            : this(layout)
        {
            FilePath = filePath;
        }

        public void Append(Message message)
        {
            string formattedLogEntry = _layout.Layout(message);
            try
            {
                File.AppendAllText(FilePath, formattedLogEntry + Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
