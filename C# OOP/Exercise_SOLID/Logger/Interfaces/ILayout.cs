namespace Logger.Interfaces
{
    public interface ILayout
    {
        string Layout(string dateTime, ReportLevels reportLevel, string message);
    }
}
