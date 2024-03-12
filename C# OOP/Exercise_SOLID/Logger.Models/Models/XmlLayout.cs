using Logger.Interfaces;
using System.Xml.Linq;

namespace Logger
{
    public class XmlLayout : ILayout
    {
        public string Layout(Message message)
        {
            XElement logEntry = new XElement("log",
                new XElement("date", message.DateTime),
                new XElement("level", message.LogLevel),
                new XElement("message", message.LogMessage));

            return logEntry.ToString();
        }
    }
}
