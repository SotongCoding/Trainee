using System.Threading;
using Cysharp.Threading.Tasks;
using SotongStudio.Plugins.DI;
using SotongStudio.Trainee.Shared.Adventure.Data;
using UnityEngine;
using UnityEngine.Events;

namespace SotongStudio.Trainee.Gameplay.Facility.Recruit.Screen
{
    public interface IRecruitFacilityPlayerAction
    {
        UnityEvent OnRecruitAdventure { get; }
        UnityEvent OnKeepAdventure { get; }

    }
    public interface IRecruitFacilityLogic : ISceneLogic, IRecruitFacilityPlayerAction
    {
        void ShowNotPossiblePopup();
        UniTask ShowRecruitProcessSequenceAsync(IAdventureMetaData adventureResult, CancellationToken cancellationToken);

        void OpenFacility(); 
        void CloseFacility();
    }

    public class RecruitFacilityLogic : IRecruitFacilityLogic
    {
        private readonly IRecruitAdventureProfileSubLogic _adventureProfile;
        private readonly IRecruitFacilityView _view;

        public UnityEvent OnRecruitAdventure => _view.OnRecruitAdventure;
        public UnityEvent OnKeepAdventure => _view.OnKeepAdventure;

        public RecruitFacilityLogic(IRecruitFacilityView view,
                                    IRecruitAdventureProfileSubLogic adventureProfile)
        {
            _view = view;
            _adventureProfile = adventureProfile;
        }

        public void OpenFacility()
        {
            _view.Show();
        }
        
        public void ShowNotPossiblePopup()
        {
            Debug.Log("Cannot Recruit. Already have Trained Advenuture");
            //TODO Create General Popup
            //_generalPopupService.Show(GeneralPopup.CreateSimpleMessage("Cannot Recruit. Already have Trained Advenuture"));
        }

        public async UniTask ShowRecruitProcessSequenceAsync(IAdventureMetaData adventureResult, CancellationToken cancellationToken)
        {
            _adventureProfile.SetupInfo(adventureResult);  
        }

        public void CloseFacility()
        {
            _view.Hide();
        }
    }
}