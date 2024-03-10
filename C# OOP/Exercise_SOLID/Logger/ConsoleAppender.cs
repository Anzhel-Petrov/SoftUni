using System;
using Logger.Interfaces;

namespace Logger
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout _layout;

        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }

        public void Append(string dateTime, ReportLevels reportLevel, string message)
        {
            Console.WriteLine(_layout.Layout(dateTime, reportLevel, message));
        }
    }
}
