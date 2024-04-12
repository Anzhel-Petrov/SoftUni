using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public class ContentMember : TeamMember
{
    private string _path;
    private List<string> _paths = new(){ "CSharp", "JavaScript", "Python", "Java" };
    public ContentMember(string name, string path) : base(name, path)
    {
        Path = path;
    }

    public override string Path
    {
        get => _path;
        protected set
        {
            if (!_paths.Contains(value))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, value));
            }

            _path = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Path} path. Currently working on {this.InProgress.Count} tasks.";
    }
}