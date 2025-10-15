using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI.LogicLoader;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Village.Screen
{
    public class VillageCoordinator : IAsyncStartable
    {
        private readonly IVillageController _controller;
        private readonly ILogicLoader<IVillageLogic> _logicLoader;
        private IVillagePlayerAction _playerAction;

        public VillageCoordinator(IVillageController controller,
                                  ILogicLoader<IVillageLogic> logicLoader)
        {
            _controller = controller;
            _logicLoader = logicLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            var logic = await _logicLoader.LoadLogicAsync(cancellation);
            _playerAction = logic;

            _playerAction.OnSelectFacility.AddListener(_controller.AccessFacility);
        }
    }
}
