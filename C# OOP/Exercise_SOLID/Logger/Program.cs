using Logger.Models.Interfaces;
using Logger.Models.Models;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender fileAppender = new FileAppender(xmlLayout);

            ILogger logger = new Logger(fileAppender);
            logger.AddAppender(consoleAppender);

            logger.Error("Error parsing JSON.");
            logger.Info("User Pesho successfully registered.");
            logger.Error("Error parsing JSON.");
            logger.Info("User Pesho successfully registered.");
        }
    }
}
