using System.Runtime.CompilerServices;
using System.Text;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core;

public class Controller : IController
{
    private IRepository<IInfluencer> _influencerRepository;
    private IRepository<ICampaign> _campaignRepository;

    public Controller()
    {
        _influencerRepository = new InfluencerRepository();
        _campaignRepository = new CampaignRepository();
    }
    public string RegisterInfluencer(string typeName, string username, int followers)
    {
        IInfluencer influencer;
        if (typeName == nameof(BloggerInfluencer))
        {
            influencer = new BloggerInfluencer(username, followers);
        }
        else if (typeName == nameof(BusinessInfluencer))
        {
            influencer = new BusinessInfluencer(username, followers);
        }
        else if (typeName == nameof(FashionInfluencer))
        {
            influencer = new FashionInfluencer(username, followers);
        }
        else
        {
            return string.Format(OutputMessages.InfluencerInvalidType, typeName);
        }

        if (_influencerRepository.FindByName(influencer.Username) is not null)
        {
            return string.Format(OutputMessages.UsernameIsRegistered, influencer.Username,
                _influencerRepository.GetType().Name);
        }
        
        _influencerRepository.AddModel(influencer);
        return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, influencer.Username);
    }

    public string BeginCampaign(string typeName, string brand)
    {
        if (typeName != nameof(ProductCampaign) && typeName != nameof(ServiceCampaign))
        {
            return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
        }

        if (_campaignRepository.FindByName(brand) is not null)
        {
            return string.Format(OutputMessages.CampaignDuplicated, brand);
        }

        ICampaign campaign = typeName == nameof(ServiceCampaign)
            ? new ServiceCampaign(brand)
            : new ProductCampaign(brand);
        
        _campaignRepository.AddModel(campaign);
        return string.Format(OutputMessages.CampaignStartedSuccessfully, campaign.Brand, campaign.GetType().Name);
    }

    public string AttractInfluencer(string brand, string username)
    {
        if(_influencerRepository.FindByName(username) is null)
        {
            return string.Format(OutputMessages.InfluencerNotFound, _influencerRepository.GetType().Name, username);
        }

        if (_campaignRepository.FindByName(brand) is null)
        {
            return string.Format(OutputMessages.CampaignNotFound, brand);
        }

        IInfluencer influencer = _influencerRepository.FindByName(username);
        ICampaign campaign = _campaignRepository.FindByName(brand);

        if (campaign.Contributors.Contains(influencer.Username))
        {
            return string.Format(OutputMessages.InfluencerAlreadyEngaged, influencer.Username, campaign.Brand);
        }

        if (campaign.GetType().Name == nameof(ProductCampaign))
        {
            if (influencer.GetType().Name == nameof(BloggerInfluencer))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, influencer.Username, campaign.Brand);
            }
        }
        else if (campaign.GetType().Name == nameof(ServiceCampaign))
        {
            if (influencer.GetType().Name == nameof(FashionInfluencer))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, influencer.Username, campaign.Brand);
            }
        }

        if (campaign.Budget < influencer.CalculateCampaignPrice())
        {
            return string.Format(OutputMessages.UnsufficientBudget, campaign.Brand, influencer.Username);
        }
        
        campaign.Engage(influencer);
        influencer.EnrollCampaign(brand);
        influencer.EarnFee(influencer.CalculateCampaignPrice());
        return string.Format(OutputMessages.InfluencerAttractedSuccessfully, influencer.Username, campaign.Brand);
    }

    public string FundCampaign(string brand, double amount)
    {
        if (_campaignRepository.FindByName(brand) is null)
        {
            return string.Format(OutputMessages.InvalidCampaignToFund);
        }

        if (amount <= 0)
        {
            return string.Format(OutputMessages.NotPositiveFundingAmount);
        }

        ICampaign campaign = _campaignRepository.FindByName(brand);
        campaign.Gain(amount);
        return string.Format(OutputMessages.CampaignFundedSuccessfully, campaign.Brand, amount);
    }

    public string CloseCampaign(string brand)
    {
        if (_campaignRepository.FindByName(brand) is null)
        {
            return string.Format(OutputMessages.InvalidCampaignToClose);
        }

        ICampaign campaign = _campaignRepository.FindByName(brand);

        if (campaign.Budget <= 10000)
        {
            return string.Format(OutputMessages.CampaignCannotBeClosed, campaign.Brand);
        }
        
        foreach (String influencerName in campaign.Contributors)
        {
            IInfluencer influencer = _influencerRepository.FindByName(influencerName);
            influencer.EarnFee(2000);
            influencer.EndParticipation(brand);
        }

        _campaignRepository.RemoveModel(campaign);
        return string.Format(OutputMessages.CampaignClosedSuccessfully, campaign.Brand);
    }

    public string ConcludeAppContract(string username)
    {
        if(_influencerRepository.FindByName(username) is null)
        {
            return string.Format(OutputMessages.InfluencerNotSigned, username);
        }
        
        IInfluencer influencer = _influencerRepository.FindByName(username);

        if (influencer.Participations.Any())
        {
            return string.Format(OutputMessages.InfluencerHasActiveParticipations, influencer.Username);
        }

        _influencerRepository.RemoveModel(influencer);
        return string.Format(OutputMessages.ContractConcludedSuccessfully, username);

    }

    public string ApplicationReport()
    {
        StringBuilder sb = new StringBuilder();
        foreach (IInfluencer influencer in _influencerRepository.Models
                     .OrderByDescending(i => i.Income)
                     .ThenByDescending(i => i.Followers))
        {
            
            sb.AppendLine(influencer.ToString().Trim());
            if (influencer.Participations.Any())
            {
                sb.AppendLine("Active Campaigns:");
                foreach (String participationName in influencer.Participations.OrderBy(p => p))
                {
                    ICampaign campaign = _campaignRepository.FindByName(participationName);
                    sb.AppendLine($"--{campaign.ToString().Trim()}");
                }
            }
        }

        return sb.ToString().Trim();
    }
}