using System.Text;
using TheContentDepartment.Core.Contracts;
using TheContentDepartment.Models;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories;
using TheContentDepartment.Repositories.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Core;

public class Controller : IController
{
    private IRepository<ITeamMember> _teamMemberRepository;
    private IRepository<IResource> _resourceRepository;
    public Controller()
    {
        _teamMemberRepository = new MemberRepository();
        _resourceRepository = new ResourceRepository();
    }
    public string JoinTeam(string memberType, string memberName, string path)
    {
        if (memberType != nameof(TeamLead) && memberType != nameof(ContentMember))
        {
            return string.Format(OutputMessages.MemberTypeInvalid, memberType);
        }

        if (memberType == nameof(ContentMember) && _teamMemberRepository.Models.Any(p => p.Path == path))
        {
            return string.Format(OutputMessages.PositionOccupied);
        }

        if (_teamMemberRepository.TakeOne(memberName) is not null)
        {
            return string.Format(OutputMessages.MemberExists, memberName);
        }

        ITeamMember member = memberType == "TeamLead"
            ? new TeamLead(memberName, path)
            : new ContentMember(memberName, path);

        _teamMemberRepository.Add(member);
        return string.Format(OutputMessages.MemberJoinedSuccessfully, memberName);
    }

    public string CreateResource(string resourceType, string resourceName, string path)
    {
        if (resourceType != nameof(Exam) && resourceType != nameof(Presentation) && resourceType != nameof(Workshop))
        {
            return string.Format(OutputMessages.ResourceTypeInvalid, resourceType);
        }

        ITeamMember member = _teamMemberRepository.Models.FirstOrDefault(t => t.Path == path);
        
        if (member is null)
        {
            return string.Format(OutputMessages.NoContentMemberAvailable, resourceName);
        }

        if (member.InProgress.Contains(resourceName))
        {
            return string.Format(OutputMessages.ResourceExists, resourceName);
        }
        
        IResource resource = null;
        switch (resourceType)
        {
            case "Exam":
                resource = new Exam(resourceName, member.Name);
                break;

            case "Workshop":
                resource = new Workshop(resourceName ,member.Name);
                break;
            
            case "Presentation":
                resource = new Presentation(resourceName, member.Name);
                break;
        }
            
        member.WorkOnTask(resourceName);
        _resourceRepository.Add(resource);
        return string.Format(OutputMessages.ResourceCreatedSuccessfully, member.Name, resourceType, resourceName);
    }

    public string LogTesting(string memberName)
    {
        ITeamMember member = _teamMemberRepository.TakeOne(memberName);
        ITeamMember teamLead= _teamMemberRepository.Models.FirstOrDefault(t => t.GetType().Name == nameof(TeamLead))!;
        
        if (member is null)
        {
            return string.Format(OutputMessages.WrongMemberName);
        }

        IResource resource = _resourceRepository.Models
            .Where(r => r.Creator == member.Name)
            .Where(r => r.IsTested == false)
            .OrderBy(r => r.Priority)
            .FirstOrDefault();

        if (resource is null)
        {
            return string.Format(OutputMessages.NoResourcesForMember, member.Name);
        }
        
        member.FinishTask(resource.Name);
        teamLead.WorkOnTask(resource.Name);
        resource.Test();
        return string.Format(OutputMessages.ResourceTested, resource.Name);
    }

    public string ApproveResource(string resourceName, bool isApprovedByTeamLead)
    {
        IResource? resource = _resourceRepository.TakeOne(resourceName);
        ITeamMember teamLead= _teamMemberRepository.Models.FirstOrDefault(t => t.GetType().Name == nameof(TeamLead))!;
        
        if (resource.IsTested)
        {
            if (isApprovedByTeamLead)
            {
                resource.Approve();
                teamLead.FinishTask(resourceName);
                return string.Format(OutputMessages.ResourceApproved, teamLead.Name, resource.Name);
            }

            resource.Test();
            return string.Format(OutputMessages.ResourceReturned, teamLead.Name, resource.Name);
        }

        return string.Format(OutputMessages.ResourceNotTested, resource.Name);
    }

    public string DepartmentReport()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Finished Tasks:");
        
        foreach (IResource? resource in _resourceRepository.Models.Where(r => r.IsApproved))
        {
            sb.AppendLine($"--{resource.ToString()?.Trim()}");
        }
        
        sb.AppendLine("Team Report:");
        ITeamMember teamLead= _teamMemberRepository.Models.FirstOrDefault(t => t.GetType().Name == nameof(TeamLead))!;
        sb.AppendLine($"--{teamLead.ToString()!.Trim()}");
        
        foreach (ITeamMember teamMember in _teamMemberRepository.Models.Where(t => t.Path != "Master"))
        {
            sb.AppendLine($"{teamMember.ToString()?.Trim()}");
        }

        return sb.ToString().Trim();
    }
}