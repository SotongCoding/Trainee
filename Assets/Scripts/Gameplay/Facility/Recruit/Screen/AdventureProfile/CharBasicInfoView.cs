using SotongStudio.Trainee.Shared.Adventure.Class;
using SotongStudio.Trainee.Shared.Adventure.Rank;
using TMPro;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public interface ICharBasicInfoView
    {
        void Setup(AdventureClass jobClass, AdventureRank rank);
    }

    public class CharBasicInfoView : MonoBehaviour, ICharBasicInfoView
    {
        [SerializeField] private TMP_Text _classText;
        [SerializeField] private TMP_Text _rankText;
        public void Setup(AdventureClass jobClass, AdventureRank rank)
        {
            _classText.text = jobClass.ToString();
            _rankText.text = rank.ToString();
        }

    }
}
