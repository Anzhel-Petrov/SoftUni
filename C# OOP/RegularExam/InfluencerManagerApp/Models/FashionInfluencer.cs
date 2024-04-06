namespace InfluencerManagerApp.Models;

public class FashionInfluencer : Influencer
{
    private const double BaseEngagementRate = 4.0;
    private const double BaseFactor = 0.1;
    public FashionInfluencer(string userName, int followers) : base(userName, followers, BaseEngagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)Math.Floor(this.Followers * this.EngagementRate * BaseFactor);
    }
}