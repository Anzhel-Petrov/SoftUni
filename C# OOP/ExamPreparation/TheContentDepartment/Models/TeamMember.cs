using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class TeamMember : ITeamMember
{
    private string _name;
    private List<string> _resources;
    
    
    public TeamMember(string name, string path)
    {
        Name = name;
        Path = path;
        _resources = new List<string>();
    }
    public string Name
    {
        get => _name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);
            }
            _name = value;
        }
    }
    public abstract string Path
    {
        get;
        protected set;
    }
    
    public IReadOnlyCollection<string> InProgress => _resources.AsReadOnly();

    public void WorkOnTask(string resourceName)
    {
        _resources.Add(resourceName);
    }

    public void FinishTask(string resourceName)
    {
        _resources.Remove(resourceName);
    }
}