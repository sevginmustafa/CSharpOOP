using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Interfaces;
using System;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        private MissionState state;

        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }
        public string State
        {
            get
            {
                return state.ToString();
            }

            private set
            {
                MissionState state;

                if (!Enum.TryParse(value, out state))
                {
                    throw new ArgumentException();
                }

                this.state = state;
            }
        }

        public void CompleteMission()
        {
            state = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
