using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball_BusinessLogic.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> _playerRepository;
        private IRepository<ITeam> _teamRepository;

        public Controller()
        {
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
        }
        public string NewTeam(string name)
        {
            ITeam team = new Team(name);
            if (_teamRepository.ExistsModel(team.Name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, team.Name, _teamRepository.GetType().Name);
            }

            _teamRepository.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, team.Name, _teamRepository.GetType().Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(Goalkeeper) && typeName != nameof(ForwardWing) && typeName != nameof(CenterBack))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (_playerRepository.ExistsModel(name))
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, _playerRepository.GetType().Name, _playerRepository.GetModel(name).GetType().Name);
            }

            IPlayer player;

            if (typeName == nameof(Goalkeeper))
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == nameof(ForwardWing))
            {
                player = new ForwardWing(name);
            }
            else
            {
                player = new CenterBack(name);
            }

            _playerRepository.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = _playerRepository.GetModel(playerName);
            ITeam team = _teamRepository.GetModel(teamName);

            if (!_playerRepository.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, _playerRepository.GetType().Name);
            }

            if (!_teamRepository.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, _teamRepository.GetType().Name);
            }

            if (player.Team is not null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, player.Name, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, player.Name, team.Name);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = _teamRepository.GetModel(firstTeamName);
            ITeam secondTeam = _teamRepository.GetModel(secondTeamName);

            if (firstTeam.OverallRating >= secondTeam.OverallRating)
            {
                if (firstTeam.OverallRating == secondTeam.OverallRating)
                {
                    firstTeam.Draw();
                    secondTeam.Draw();
                    return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
                }

                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
            }

            firstTeam.Lose();
            secondTeam.Win();
            return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = _teamRepository.GetModel(teamName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{team.Name}***");

            foreach (IPlayer player in team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {   
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            foreach (ITeam team in _teamRepository.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
