using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
            Capacity = capacity;
        }

        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }
        public int Capacity { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (this.Inbox.Count < this.Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            return this.Inbox.Remove(this.Inbox.FirstOrDefault(x => x.Sender == sender));
        }

        public int ArchiveInboxMessages()
        {
            int mailsCount = this.Inbox.Count;
            this.Archive.AddRange(this.Inbox.ToArray());
            this.Inbox.Clear();
            return mailsCount;
        }

        public string GetLongestMessage()
        {
            return this.Inbox.MaxBy(x => x.Body).ToString().Trim();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
