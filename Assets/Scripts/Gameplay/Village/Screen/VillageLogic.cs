using System;
using System.Collections.Generic;
using SotongStudio.Plugins.DI;
using SotongStudio.Trainee.Gameplay.Facility;
using UnityEngine;
using UnityEngine.Events;

#nullable enable
namespace SotongStudio.Trainee.Gameplay.Village.Screen
{
    public interface IVillagePlayerAction
    {
        UnityEvent<VillageFacility, string?> OnSelectFacility { get; }
    }
    public interface IVillageLogic : ISceneLogic, IVillagePlayerAction, IDisposable
    {
        void OpenVillage();
        void CloseVillage();
    }
    public class VillageLogic : IVillageLogic
    {
        public UnityEvent<VillageFacility, string?> OnSelectFacility { get; private set; } = new();
        private readonly IReadOnlyList<IVillageFacilityTrigger> _facilityTriggers;
        private readonly IVillageView _view;
        private bool _disposedValue;

        public VillageLogic(IReadOnlyList<IVillageFacilityTrigger> facilityTriggers,
                            IVillageView view)
        {
            _facilityTriggers = facilityTriggers;
            _view = view;

            foreach (var facility in _facilityTriggers)
            {
                facility.OnSelectFacility.AddListener(AccessFacility);
            }
        }

        public void OpenVillage()
        {
            _view.Show();
        }

        private void AccessFacility(VillageFacility facility, string? identifier)
        {
            OnSelectFacility.Invoke(facility, identifier);
        }

        public void CloseVillage()
        {
            _view.Hide();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (var facility in _facilityTriggers)
                    {
                        facility.OnSelectFacility.RemoveListener(AccessFacility);
                    }
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
