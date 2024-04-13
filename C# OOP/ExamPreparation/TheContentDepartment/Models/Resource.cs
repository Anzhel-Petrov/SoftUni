using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models;

public abstract class Resource : IResource
{
    private string _name;
    private string _creator;
    private int _priority;
    private bool _isTested;
    private bool _isApproved;

    public Resource(string name, string creator, int priority)
    {
        Name = name;
        Creator = creator;
        Priority = priority;
        _isApproved = false;
        _isTested = false;
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

    public string Creator
    {
        get => _creator;
        private set => _creator = value;
    }
    public int Priority
    {
        get => _priority;
        private set => _priority = value;
    }
    public bool IsTested
    {
        get => _isTested;
        private set => _isTested = value;
    }
    public bool IsApproved
    {
        get => _isApproved;
        private set => _isApproved = value;
    }
    
    public void Test()
    {
        _isTested = !_isTested;
    }

    public void Approve()
    {
        _isApproved = !_isApproved;
    }

    public override string ToString()
    {
        return $"{Name} ({this.GetType().Name}), Created By: {Creator}";
    }
}