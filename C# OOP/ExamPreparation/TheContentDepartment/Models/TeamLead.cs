using System.Runtime;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class TeamLead : TeamMember
{
    private string _path;
    public TeamLead(string name,string path) : base(name, path)
    {
        Path = path;
    }

    public override string Path
    {
        get => _path;
        protected set
        {
            if (value != "Master")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
            }

            _path = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} ({this.GetType().Name}) - Currently working on {this.InProgress.Count} tasks.";
    }
}