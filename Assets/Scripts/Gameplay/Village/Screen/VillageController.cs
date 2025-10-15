using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI.LogicLoader;
using SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen;
using SotongStudio.Trainee.Gameplay.Facility.Training.Screen;
using UnityEngine;

#nullable enable

namespace SotongStudio.Trainee.Gameplay.Village.Screen
{
    public interface IVillageController
    {
        void LoadVillage();
        void AccessFacility(VillageFacility facility, string? identifier);
        void AccessFacility(VillageFacility facility) => AccessFacility(facility, null);
    }
    public class VillageController : IVillageController, IDisposable
    {

        private readonly ILogicLoader<IVillageLogic> _villageLogicLoader;
        private IVillageLogic? _villageLogic;

        private readonly ITrainingFacilityController _trainingFacility;
        private readonly IRecruitFacilityController _recruitFacilty;


        private bool IsReady => _villageLogic != null;
        private readonly CancellationTokenSource _cts = new();
        private bool _disposedValue;


        public VillageController(ILogicLoader<IVillageLogic> villageLogicLoader,
                                 ITrainingFacilityController trainingFacility,
                                 IRecruitFacilityController recruitFacility)
        {
            _villageLogicLoader = villageLogicLoader;

            _trainingFacility = trainingFacility;
            _recruitFacilty = recruitFacility;
        }


        public void LoadVillage()
        {
            LoadVillageAsync(_cts.Token).Forget();
        }
        private async UniTask LoadVillageAsync(CancellationToken cancellationToken)
        {
            if (!IsReady) { _villageLogic = await _villageLogicLoader.LoadLogicAsync(cancellationToken); }

            _villageLogic!.OpenVillage();

        }

        public void AccessFacility(VillageFacility facility, string? identifier)
        {
            Debug.Log($"Access Facility : {facility}");
            switch (facility)
            {
                case VillageFacility.TrainingFacility: OpenTrainingFacility(identifier); break;
                case VillageFacility.RecruitFacility: OpenRecruitFacility(); break;

                default: throw new System.InvalidOperationException($"Cannot Access facility {facility}");
            }
        }


        #region Training Facility
        private void OpenTrainingFacility(string? trainingId)
        {
            if (string.IsNullOrWhiteSpace(trainingId))
            {
                throw new System.InvalidOperationException($"Cannot Open Training Facility if Id NULL");
            }
            OpenTrainingFacilityAsync(trainingId, _cts.Token).Forget();
        }
        private async UniTask OpenTrainingFacilityAsync(string trainingId, CancellationToken cancellationToken)
        {
            await _trainingFacility.SetupTrainingAsync(trainingId, cancellationToken);
            await _trainingFacility.OpenFacilityAsync(cancellationToken);
        }
        #endregion

        #region Recruit Facility
        private void OpenRecruitFacility()
        {
            OpenRecruitFacilityAsync(_cts.Token).Forget();
        }
        private UniTask OpenRecruitFacilityAsync(CancellationToken cancellationToken)
        {
            return _recruitFacilty.OpenFacilityAsync(cancellationToken);
        }
        #endregion


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
