using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Influencer : IInfluencer
{
    private string _userName;
    private int _followers;
    private double _engagementRate;
    private double _income;
    private List<string> _participations;

    public Influencer(string userName, int followers, double engagementRate)
    {
        Username = userName;
        Followers = followers;
        EngagementRate = engagementRate;
        _participations = new List<string>();
    }
    public string Username
    {
        get => _userName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
            }

            _userName = value;
        }
    }
    public int Followers
    {
        get => _followers;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
            }

            _followers = value;
        }
    }
    public double EngagementRate
    {
        get => _engagementRate;
        private set => _engagementRate = value;
    }
    public double Income
    {
        get => _income;
        private set => _income = value;
    }
    public IReadOnlyCollection<string> Participations => _participations.AsReadOnly();
    public void EarnFee(double amount)
    {
        this.Income += amount;
    }

    public void EnrollCampaign(string brand)
    {
        this._participations.Add(brand);
    }

    public void EndParticipation(string brand)
    {
        this._participations.Remove(brand);
    }

    public abstract int CalculateCampaignPrice();

    public override string ToString()
    {
        return $"{Username} - Followers: {Followers}, Total Income: {Income}";
    }
}