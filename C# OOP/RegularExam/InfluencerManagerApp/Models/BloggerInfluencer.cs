namespace InfluencerManagerApp.Models;

public class BloggerInfluencer : Influencer
{
    private const double BaseEngagementRate = 2.0;
    private const double BaseFactor = 0.2;
    public BloggerInfluencer(string userName, int followers) : base(userName, followers, BaseEngagementRate)
    {
    }

    public override int CalculateCampaignPrice()
    {
        return (int)Math.Floor(this.Followers * this.EngagementRate * BaseFactor);
    }
}