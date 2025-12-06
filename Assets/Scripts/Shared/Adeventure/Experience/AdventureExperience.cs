using System;
using Newtonsoft.Json.Bson;

namespace SotongStudio.Trainee.Shared.Adventure.Experience
{
    public interface IAdventureExperience
    {
        ushort ExpPoint { get; }
        ushort Level { get; }
    }
    public class AdventureExperience : IAdventureExperience
    {
        public ushort ExpPoint { get; private set; }

        public ushort Level { get; private set; }

        public AdventureExperience(ushort experience, ushort level)
        {
            ExpPoint = experience;
            Level = level;
        }

        public AdventureExperience() : this(0, 1)
        {
        }

        public void ChangeCurrentExperience(ushort experience)
        {
            ExpPoint = experience;
        }
        public void ChangeCurrentLevel(ushort level)
        {
            Level = level;
        }
    }
}
