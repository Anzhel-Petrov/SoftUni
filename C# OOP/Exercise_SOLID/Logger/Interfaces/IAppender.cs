namespace Logger.Interfaces
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevels reportLevel, string message);
    }
}
