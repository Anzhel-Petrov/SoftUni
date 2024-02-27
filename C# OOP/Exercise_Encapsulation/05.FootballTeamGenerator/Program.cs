using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Team> teams = new List<Team>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(";");
                string commandType = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (commandType)
                    {
                        case "Team":

                            AddTeam(teams, teamName);

                            break;
                        case "Add":

                            Team teamAdd = teams.FirstOrDefault(t => t.Name == teamName);

                            if (teamAdd is null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);

                            Player addedPlayer = new Player(playerName, new Stats(endurance, sprint, dribble, passing, shooting));
                            teamAdd.AddPlayer(addedPlayer);

                            break;
                        case "Remove":

                            string playerToRemove = tokens[2];
                            Team teamToRemove = teams.FirstOrDefault(x => x.Name == teamName);

                            if (teamToRemove is null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            teamToRemove.RemovePlayer(playerToRemove);

                            break;
                        case "Rating":

                            Team teamRating = teams.FirstOrDefault(x => x.Name == teamName);

                            if (teamRating is null)
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }

                            Console.WriteLine($"{teamRating.Name} - {teamRating.Rating}");

                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void AddTeam(List<Team> teams, string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }
    }

}
