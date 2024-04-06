namespace InfluencerManagerApp.Models;

public class ServiceCampaign : Campaign
{
    private const double BaseBudget = 30000;
    public ServiceCampaign(string brand) : base(brand, BaseBudget)
    {
    }
}