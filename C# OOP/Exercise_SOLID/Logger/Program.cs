using Logger.Interfaces;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();

            IAppender consoleAppender = new ConsoleAppender(xmlLayout);
            IAppender fileAppender = new FileAppender(simpleLayout);

            ILogger logger = new Logger(fileAppender);
            logger.AddAppender(consoleAppender);

            logger.Error("Error parsing JSON.");
            logger.Info("User Pesho successfully registered.");
            logger.Error("Error parsing JSON.");
            logger.Info("User Pesho successfully registered.");
        }
    }
}
