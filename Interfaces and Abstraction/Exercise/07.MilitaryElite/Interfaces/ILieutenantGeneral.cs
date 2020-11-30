using System.Collections.Generic;

namespace _07.MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral 
    {
        public ICollection<IPrivate> Privates { get; }
    }
}
