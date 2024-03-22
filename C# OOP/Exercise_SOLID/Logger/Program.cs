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
            consoleAppender.LogLevel = LogLevel.Error;

            ILogger logger = new Logger(fileAppender);
            logger.AddAppender(consoleAppender);

            logger.Info("Everything seems fine");
            logger.Warning("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
            logger.Fatal("mscorlib.dll does not respond");
        }
    }
}
