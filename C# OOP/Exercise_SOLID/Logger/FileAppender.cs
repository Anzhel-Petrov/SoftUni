using Logger.Interfaces;
using System;

namespace Logger
{
    public class FileAppender : IAppender
    {
        private readonly ILayout _layout;
        private readonly ILogFile _logFile;

        public FileAppender(ILayout layout, ILogFile logfile)
        {
            _layout = layout;
            _logFile = logfile;
        }
        public void Append(string dateTime, ReportLevels reportLevel, string message)
        {
            Console.WriteLine(_layout.Layout(dateTime, reportLevel, message));
            _logFile.Write(message);
        }
    }
}
