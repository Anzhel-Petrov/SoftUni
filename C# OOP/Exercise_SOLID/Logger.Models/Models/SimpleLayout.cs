using Logger.Models.Interfaces;

namespace Logger.Models.Models
{
    public class SimpleLayout : ILayout
    {
        public string Layout(Message message)
        {
            return $"{message.DateTime} - {message.LogLevel} - {message.LogMessage}";
        }
    }
}
