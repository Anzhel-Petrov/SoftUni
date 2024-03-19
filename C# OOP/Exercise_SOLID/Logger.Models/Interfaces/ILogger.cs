namespace Logger.Models.Interfaces
{
    public interface ILogger
    {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);
        void Fatal(string message);
        public void AddAppender(IAppender appender);
    }
}
