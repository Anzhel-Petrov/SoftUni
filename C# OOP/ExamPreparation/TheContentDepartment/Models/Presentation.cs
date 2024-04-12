namespace TheContentDepartment.Models;

public class Presentation : Resource
{
    private const int _priority = 2;
    public Presentation(string name, string creator) : base(name, creator, _priority)
    {
    }
}