using System.Collections.Generic;

namespace _07.MilitaryElite.Interfaces
{
    public interface IEngineer 
    {
        public ICollection<IRepair> Repairs { get; }
    }
}
