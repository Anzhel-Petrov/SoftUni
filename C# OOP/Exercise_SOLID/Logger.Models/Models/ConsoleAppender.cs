﻿using Logger.Models.Interfaces;

namespace Logger.Models.Models
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout _layout;

        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }

        public LogLevel LogLevel { get; set; }

        public void Append(Message message)
        {
            Console.WriteLine(_layout.Layout(message));
        }
    }
}
