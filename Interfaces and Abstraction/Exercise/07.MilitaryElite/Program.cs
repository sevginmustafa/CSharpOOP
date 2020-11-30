using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();

                if (command[0] == "Private")
                {
                    string id = command[1];
                    string firstName = command[2];
                    string lastName = command[3];
                    decimal salary = decimal.Parse(command[4]);

                    soldiers.Add(new Private(id, firstName, lastName, salary));
                }
                else if (command[0] == "LieutenantGeneral")
                {
                    string id = command[1];
                    string firstName = command[2];
                    string lastName = command[3];
                    decimal salary = decimal.Parse(command[4]);

                    List<IPrivate> privates = new List<IPrivate>();

                    for (int i = 5; i < command.Length; i++)
                    {
                        IPrivate check = (IPrivate)soldiers.FirstOrDefault(x => x.Id == command[i]);

                        privates.Add(check);
                    }

                    soldiers.Add(new LieutenantGeneral(id, firstName, lastName, salary, privates));
                }
                else if (command[0] == "Engineer")
                {
                    try
                    {
                        string id = command[1];
                        string firstName = command[2];
                        string lastName = command[3];
                        decimal salary = decimal.Parse(command[4]);
                        string corp = command[5];

                        List<IRepair> repairs = new List<IRepair>();

                        for (int i = 6; i < command.Length; i += 2)
                        {
                            repairs.Add(new Repair(command[i], int.Parse(command[i + 1])));
                        }

                        soldiers.Add(new Engineer(id, firstName, lastName, salary, corp, repairs));
                    }
                    catch (ArgumentException)
                    {
                    }
                }
                else if (command[0] == "Commando")
                {
                    string id = command[1];
                    string firstName = command[2];
                    string lastName = command[3];
                    decimal salary = decimal.Parse(command[4]);
                    string corp = command[5];

                    List<IMission> missions = new List<IMission>();

                    for (int i = 6; i < command.Length; i += 2)
                    {
                        try
                        {
                            missions.Add(new Mission(command[i], command[i + 1]));
                        }
                        catch (ArgumentException)
                        {
                        }
                    }

                    soldiers.Add(new Commando(id, firstName, lastName, salary, corp, missions));
                }
                else if (command[0] == "Spy")
                {
                    string id = command[1];
                    string firstName = command[2];
                    string lastName = command[3];
                    int codeNumber = int.Parse(command[4]);

                    soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
