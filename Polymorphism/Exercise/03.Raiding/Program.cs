using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count != n)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        heroes.Add(new Druid(name));
                        break;
                    case "Paladin":
                        heroes.Add(new Paladin(name));
                        break;
                    case "Rogue":
                        heroes.Add(new Rogue(name));
                        break;
                    case "Warrior":
                        heroes.Add(new Warrior(name));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        continue;
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (heroes.Sum(x => x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
