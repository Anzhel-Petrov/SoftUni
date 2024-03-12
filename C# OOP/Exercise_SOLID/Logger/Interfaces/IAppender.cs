namespace Logger.Interfaces
{
    public interface IAppender
    {
        void Append(Message message);
    }
}
