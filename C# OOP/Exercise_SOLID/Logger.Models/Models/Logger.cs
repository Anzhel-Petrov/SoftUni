using Logger.Interfaces;
using System.Collections.Generic;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> _appenders = new List<IAppender>();

        public Logger(IAppender appender)
        {
            _appenders.Add(appender);
        }
        public void AddAppender(IAppender appender)
        {
            _appenders.Add(appender);
        }

        public void Info(string logMessage)
        {
            Log(new Message(LogLevel.Info, logMessage));
        }
        public void Warning(string logMessage)
        {
            Log(new Message(LogLevel.Warning, logMessage));
        }

        public void Error(string logMessage)
        {
            Log(new Message(LogLevel.Error, logMessage));
        }
        public void Critical(string logMessage)
        {
            Log(new Message(LogLevel.Critical, logMessage));
        }

        public void Fatal(string logMessage)
        {
            Log(new Message(LogLevel.Fatal, logMessage));

        }

        private void Log(Message message)
        {
            foreach (IAppender appender in _appenders)
            {
                appender.Append(message);
            }
        }
    }
}
