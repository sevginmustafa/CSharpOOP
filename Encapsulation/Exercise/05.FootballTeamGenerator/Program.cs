using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] command = input.Split(';');

                    if (command[0] == "Team")
                    {
                        string teamName = command[1];

                        teams.Add(new Team(teamName));
                    }
                    else if (command[0] == "Add")
                    {
                        string teamName = command[1];
                        string playerName = command[2];
                        int endurance = int.Parse(command[3]);
                        int sprint = int.Parse(command[4]);
                        int dribble = int.Parse(command[5]);
                        int passing = int.Parse(command[6]);
                        int shooting = int.Parse(command[7]);

                        if (teams.Any(x => x.Name == teamName))
                        {
                            int index = teams.FindIndex(x => x.Name == teamName);

                            teams[index].AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (command[0] == "Remove")
                    {
                        string teamName = command[1];
                        string playerName = command[2];

                        Team check = teams.FirstOrDefault(x => x.Name == teamName);

                        if (check.Players.Any(x => x.Name == playerName))
                        {
                            Player toRemove = check.Players.FirstOrDefault(x => x.Name == playerName);
                            check.RemovePlayer(toRemove);
                        }
                        else
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                    }
                    else if (command[0] == "Rating")
                    {
                        string teamName = command[1];

                        Team check = teams.FirstOrDefault(x => x.Name == teamName);

                        if (check != null)
                        {
                            double rating = 0;

                            foreach (var player in check.Players)
                            {
                                rating += player.GetStats();
                            }

                            Console.WriteLine($"{teamName} - {Math.Round(rating)}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
