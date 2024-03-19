using Logger.Models.Models;

namespace Logger.Models.Interfaces
{
    public interface ILogFile
    {
        void Write(Message message);
    }
}
