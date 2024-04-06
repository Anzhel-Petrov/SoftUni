using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Models;

public abstract class Campaign : ICampaign
{
    private string _brand;
    private double _budget;
    private List<string> _contributors;

    public Campaign(string brand, double budget)
    {
        Brand = brand;
        Budget = budget;
        _contributors = new List<string>();
    }
    public string Brand
    {
        get => _brand;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BrandIsrequired);
            }

            _brand = value;
        }
    }
    public double Budget
    {
        get => _budget;
        private set => _budget = value;
    }

    public IReadOnlyCollection<string> Contributors => _contributors.AsReadOnly();
    public void Gain(double amount)
    {
        this._budget += amount;
    }

    public void Engage(IInfluencer influencer)
    {
        this._contributors.Add(influencer.Username);
        this.Budget -= influencer.CalculateCampaignPrice();
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {Contributors.Count}";
    }
}