namespace InfluencerManagerApp.Models;

public class ProductCampaign : Campaign
{
    private const double BaseBudget = 60000;
    public ProductCampaign(string brand) : base(brand, BaseBudget)
    {
    }
}