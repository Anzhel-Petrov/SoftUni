namespace InfluencerManagerApp.Models;

public class BusinessInfluencer : Influencer
{
    private const double BaseEngagementRate = 3.0;
    private const double BaseFactor = 0.15;
    public BusinessInfluencer(string userName, int followers) : base(userName, followers, BaseEngagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)Math.Floor(this.Followers * this.EngagementRate * BaseFactor);
    }
}