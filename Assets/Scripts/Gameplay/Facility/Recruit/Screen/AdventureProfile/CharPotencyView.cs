using UnityEngine;

namespace SotongStudio.Trainee
{
    public class CharPotencyView : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _potencyBar;

        public void SetEfficiencyAmount(int amount)
        {
            int i = 0;
            for (; i < amount; i++)
            {
                _potencyBar[i].SetActive(true);
            }
            for (; i < _potencyBar.Length; i++)
            {
                _potencyBar[i].SetActive(false);
            }
        }
    }
}
