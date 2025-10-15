
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Shared.Adventure.Data;
using VContainer.Unity;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public interface IRecruitFacilityController
    {
        UniTask OpenFacilityAsync(CancellationToken cancellationToken);
        void RecruitNewAdventure();
        void KeepRecruitedAdventure();
    }

    public class RecruitFacilityController : IRecruitFacilityController, IDisposable, IAsyncStartable
    {
        private readonly IAdventureMetaDataProvider _adventureDataProvider;
        private readonly ILogicLoader<IRecruitFacilityLogic> _recruitLoader;
        private IRecruitFacilityLogic _recruitLogic;


        private bool _disposedValue;
        private readonly CancellationTokenSource _cts = new();

        public RecruitFacilityController(IAdventureMetaDataProvider adventureDataProvider,
                                         ILogicLoader<IRecruitFacilityLogic> recruitLoader)
        {
            _adventureDataProvider = adventureDataProvider;
            _recruitLoader = recruitLoader;
        }
        public async UniTask StartAsync(CancellationToken cancellation = default)
        {
            _recruitLogic = await _recruitLoader.LoadLogicAsync(cancellation);   
        }

        public UniTask OpenFacilityAsync(CancellationToken cancellationToken)
        {
            _recruitLogic.OpenFacility();
            return UniTask.CompletedTask;
        }

        public void RecruitNewAdventure()
        {
            RecruitNewAdventureAsync(_cts.Token).Forget();
        }
        public UniTask RecruitNewAdventureAsync(CancellationToken cancellationToken)
        {
            var isPossible = _adventureDataProvider.CreateNewAdventure(out var adventureResult);

            if (!isPossible)
            {
                _recruitLogic.ShowNotPossiblePopup();
            }

            return _recruitLogic.ShowRecruitProcessSequenceAsync(adventureResult ,cancellationToken);
        }


        public void KeepRecruitedAdventure()
        {

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _cts.Cancel();
                    _cts.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}