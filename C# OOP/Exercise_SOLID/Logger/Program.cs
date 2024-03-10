using Logger.Interfaces;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);

            ILogger logger = new Logger(consoleAppender);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");

            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            var file = new LogFile();

            var fileAppender = new FileAppender(simpleLayout, file);

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");

            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
