using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI.LogicLoader;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public class RecruitFacilityCoordinator : IAsyncStartable
    {
        private readonly IRecruitFacilityController _controller;
        private readonly ILogicLoader<IRecruitFacilityLogic> _logicLoader;

        private IRecruitFacilityPlayerAction _playerAction;

        public RecruitFacilityCoordinator(IRecruitFacilityController controller, ILogicLoader<IRecruitFacilityLogic> logicLoader)
        {
            _controller = controller;
            _logicLoader = logicLoader;
        }

        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            _playerAction = await _logicLoader.LoadLogicAsync(cancellation);

            _playerAction.OnRecruitAdventure.AddListener(_controller.RecruitNewAdventure);
            _playerAction.OnKeepAdventure.AddListener(_controller.KeepRecruitedAdventure);

        }
    }
}
