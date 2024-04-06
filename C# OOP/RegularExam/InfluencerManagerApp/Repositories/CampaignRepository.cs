using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;

namespace InfluencerManagerApp.Repositories;

public class CampaignRepository : IRepository<ICampaign>
{
    private List<ICampaign> _campaigns;

    public CampaignRepository()
    {
        _campaigns = new List<ICampaign>();
    }

    public IReadOnlyCollection<ICampaign> Models => _campaigns.AsReadOnly();
    public void AddModel(ICampaign model)
    {
        _campaigns.Add(model);
    }

    public bool RemoveModel(ICampaign model)
    {
        return _campaigns.Remove(model);
    }

    public ICampaign FindByName(string name)
    {
        return _campaigns.FirstOrDefault(c => c.Brand == name);
    }
}