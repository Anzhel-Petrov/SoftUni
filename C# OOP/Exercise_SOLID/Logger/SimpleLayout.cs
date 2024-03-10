using Logger.Interfaces;

namespace Logger
{
    public class SimpleLayout : ILayout
    {
        public string Layout(string dateTime, ReportLevels reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}
