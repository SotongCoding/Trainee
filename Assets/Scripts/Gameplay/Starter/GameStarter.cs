using SotongStudio.Trainee.Gameplay.Village.Screen;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Trainee
{
    public class GameStarter : MonoBehaviour
    {
        private IVillageController _villageController;

        [Inject]
        private void Inject(IVillageController villageController)
        {
            _villageController = villageController;
            _villageController.LoadVillage();
        }
    }
}
