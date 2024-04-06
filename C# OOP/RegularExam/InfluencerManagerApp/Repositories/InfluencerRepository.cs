using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class InfluencerRepository : IRepository<IInfluencer>
{
    private HashSet<IInfluencer> _influencers;

    public InfluencerRepository()
    {
        _influencers = new HashSet<IInfluencer>();
    }

    public IReadOnlyCollection<IInfluencer> Models => _influencers;
    public void AddModel(IInfluencer model)
    {
        _influencers.Add(model);
    }

    public bool RemoveModel(IInfluencer model)
    {
        return _influencers.Remove(model);
    }

    public IInfluencer FindByName(string name)
    {
        return _influencers.FirstOrDefault(i => i.Username == name);
    }
}