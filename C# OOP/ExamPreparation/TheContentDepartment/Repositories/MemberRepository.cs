using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories;

public class MemberRepository : IRepository<ITeamMember>
{
    private List<ITeamMember> _teamMembers;

    public MemberRepository()
    {
        _teamMembers = new List<ITeamMember>();
    }
    public IReadOnlyCollection<ITeamMember> Models => _teamMembers.AsReadOnly();
    public void Add(ITeamMember model)
    {
        _teamMembers.Add(model);
    }

    public ITeamMember TakeOne(string modelName)
    {
        return _teamMembers.FirstOrDefault(t => t.Name == modelName);
    }
}