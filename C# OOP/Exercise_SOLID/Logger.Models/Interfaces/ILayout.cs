using Logger.Models.Models;

namespace Logger.Models.Interfaces
{
    public interface ILayout
    {
        string Layout(Message message);
    }
}
