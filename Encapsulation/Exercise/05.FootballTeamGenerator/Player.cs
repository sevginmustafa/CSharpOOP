using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        string name;
        int endurance;
        int sprint;
        int dribble;
        int passing;
        int shooting;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }
        public int Endurance
        {
            get
            {
                return endurance;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    endurance = value;
                }
                else
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
            }
        }
        public int Sprint
        {
            get
            {
                return sprint;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    sprint = value;
                }
                else
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
            }
        }
        public int Dribble
        {
            get
            {
                return dribble;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    dribble = value;
                }
                else
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
            }
        }
        public int Passing
        {
            get
            {
                return passing;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    passing = value;
                }
                else
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
            }
        }
        public int Shooting
        {
            get
            {
                return shooting;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    shooting = value;
                }
                else
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
            }
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public double GetStats()
        {
            return (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        }
    }
}
