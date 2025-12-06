using TMPro;
using UnityEngine;

namespace SotongStudio.Trainee.Gameplay.Facility.Training.Screen
{
    public interface ICharStatNumberView
    {
        void SetCurrentNumber(ushort value);
    }

    public class CharStatNumberView : MonoBehaviour, ICharStatNumberView
    {
        [SerializeField] private TMP_Text _currentNumber;


        public void SetCurrentNumber(ushort value)
        {
            _currentNumber.text = value.ToString();
        }
    }
}
