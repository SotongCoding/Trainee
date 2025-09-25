using SotongStudio.Trainee.Shared.Adventure.Status;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Training.Screen
{
    public interface ICharStatHandledData
    {
        StatusCodex HandledStatus { get; }
    }
    public class CharStatHandledData : MonoBehaviour, ICharStatHandledData
    {
        [SerializeField]
        private StatusCodex _handledStatus;
        public StatusCodex HandledStatus => _handledStatus;
    }
}
