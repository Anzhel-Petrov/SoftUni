using Logger.Models.Models;

namespace Logger.Models.Interfaces
{
    public interface IAppender
    {
        void Append(Message message);
        LogLevel LogLevel { get; set; }
    }
}
