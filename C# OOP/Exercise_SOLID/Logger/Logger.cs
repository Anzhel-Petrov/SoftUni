using Logger.Interfaces;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly IAppender _appender;

        public Logger(IAppender appender)
        {
            _appender = appender;
        }

        public void Critical(string dateTime, string message)
        {
            _appender.Append(dateTime, ReportLevels.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            _appender.Append(dateTime, ReportLevels.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            _appender.Append(dateTime, ReportLevels.Fatal, message);

        }

        public void Info(string dateTime, string message)
        {
            _appender.Append(dateTime, ReportLevels.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            _appender.Append(dateTime, ReportLevels.Warning, message);
        }
    }
}
