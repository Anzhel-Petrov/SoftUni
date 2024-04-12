namespace TheContentDepartment.Models;

public class Exam : Resource
{
    private const int _priority = 1;
    public Exam(string name, string creator) : base(name, creator, _priority)
    {
    }
}