namespace Logger.Models.Models
{
    public class Message
    {
        public Message(LogLevel logLevel, string logMessage)
        {
            LogLevel = logLevel;
            LogMessage = logMessage;
        }
        public Message(LogLevel logLevel, string logMessage, DateTime dateTime)
            : this(logLevel, logMessage)
        {
            DateTime = dateTime;
        }

        public DateTime DateTime { get; set; } = DateTime.Now;
        public LogLevel LogLevel { get; set; }
        public string LogMessage { get; set; }
    }
}
