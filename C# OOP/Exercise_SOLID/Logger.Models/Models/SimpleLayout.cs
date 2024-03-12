using Logger.Interfaces;

namespace Logger
{
    public class SimpleLayout : ILayout
    {
        public string Layout(Message message)
        {
            return $"{message.DateTime} - {message.LogLevel} - {message.LogMessage}";
        }
    }
}
