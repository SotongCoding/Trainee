using NaughtyAttributes;
using SotongStudio.Trainee.Gameplay.Training;
using SotongStudio.Trainee.Gameplay.Training.Screen;
using SotongStudio.Trainee.Service.AdventureGenerator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee
{
    public class TestingB : MonoBehaviour
    {

        [SerializeField] private AdventureGenerator _adventureGenerator;
        [SerializeField] private IAdventureMetaDataService _advetureMetaDataService;
        [SerializeField] private IAdventureMetaDatUpdateService _advetureMetaUpdateDataService;

        private ITrainingFacilityController _trainingController;
        private IObjectResolver _resolver;
        private ITrainingService _trainingService;

        [Inject]
        private void Inject(IObjectResolver resolver,
                            AdventureGenerator adventureGenerator,
                            IAdventureMetaDataService adventureMetaDataService,
                            IAdventureMetaDatUpdateService adventureMetaDataUpdateService,
                            ITrainingService trainingService,
                            ITrainingFacilityController trainingController)
        {
            _resolver = resolver;
            _adventureGenerator = adventureGenerator;
            _advetureMetaDataService = adventureMetaDataService;
            _advetureMetaUpdateDataService = adventureMetaDataUpdateService;
            _trainingService = trainingService;
            _trainingController = trainingController;
            

        }

        //[Button]
        private void ResolveDI()
        {
            _adventureGenerator = _resolver.Resolve<AdventureGenerator>();
            _advetureMetaDataService = _resolver.Resolve<IAdventureMetaDataService>();
        }

        [Button]
        private void SimulateCreateAdventure()
        {
            var adventure = _adventureGenerator.CreateAdventureMetaData();
            Debug.Log($"{adventure}");
            _advetureMetaUpdateDataService.SetAdventureData(adventure);

            var generatedAdventure = _advetureMetaDataService.GetAdventureMetaData();

            Debug.Log($"Rank {generatedAdventure.Rank}\n Class {generatedAdventure.JobClass}" +
                                      $"\nStat : " +
                                      $"\nHealth {generatedAdventure.Statuses.FinalStatus.Health} " +
                                      $"\nPysAttack {generatedAdventure.Statuses.FinalStatus.PysAttack} PysDefense {generatedAdventure.Statuses.FinalStatus.PysDefense} " +
                                      $"\nMgcAttack {generatedAdventure.Statuses.FinalStatus.MgcAttack} MgcDefense {generatedAdventure.Statuses.FinalStatus.MgcDefense} " +
                                      $"\nCritical {generatedAdventure.Statuses.FinalStatus.Critical} Speed {generatedAdventure.Statuses.FinalStatus.Speed} Accuracy {generatedAdventure.Statuses.FinalStatus.Accuracy}" +
                                       $"\nBase Main : " +
                                      $"\nHealth {generatedAdventure.Statuses.BaseStatus.Health} " +
                                      $"\nPysAttack {generatedAdventure.Statuses.BaseStatus.PysAttack} PysDefense {generatedAdventure.Statuses.BaseStatus.PysDefense} " +
                                      $"\nMgcAttack {generatedAdventure.Statuses.BaseStatus.MgcAttack} MgcDefense {generatedAdventure.Statuses.BaseStatus.MgcDefense} " +
                                      $"\nCritical {generatedAdventure.Statuses.BaseStatus.Critical} Speed {generatedAdventure.Statuses.BaseStatus.Speed} Accuracy {generatedAdventure.Statuses.BaseStatus.Accuracy}" +
                                      $"\n\nStat Main : " +
                                      $"\nHealth {generatedAdventure.Statuses.MainStatus.Health} " +
                                      $"\nPysAttack {generatedAdventure.Statuses.MainStatus.PysAttack} PysDefense {generatedAdventure.Statuses.MainStatus.PysDefense} " +
                                      $"\nMgcAttack {generatedAdventure.Statuses.MainStatus.MgcAttack} MgcDefense {generatedAdventure.Statuses.MainStatus.MgcDefense} " +
                                      $"\nCritical {generatedAdventure.Statuses.MainStatus.Critical} Speed {generatedAdventure.Statuses.MainStatus.Speed} Accuracy {generatedAdventure.Statuses.MainStatus.Accuracy}" +
                                       $"\n\nTraining : " +
                                      $"\nHealth {generatedAdventure.Statuses.TrainingStatus.Health} " +
                                      $"\nPysAttack {generatedAdventure.Statuses.TrainingStatus.PysAttack} PysDefense {generatedAdventure.Statuses.TrainingStatus.PysDefense} " +
                                      $"\nMgcAttack {generatedAdventure.Statuses.TrainingStatus.MgcAttack} MgcDefense {generatedAdventure.Statuses.TrainingStatus.MgcDefense} " +
                                      $"\nCritical {generatedAdventure.Statuses.TrainingStatus.Critical} Speed {generatedAdventure.Statuses.TrainingStatus.Speed} Accuracy {generatedAdventure.Statuses.TrainingStatus.Accuracy}" +
                                      $"" +
                                      $"\n\n Potency : " +
                                      $"\nHealth {generatedAdventure.Potency.HealthPotency} " +
                                      $"\nPysAttack {generatedAdventure.Potency.PysAttackPotency} PysDefense {generatedAdventure.Potency.PysDefensePotency} " +
                                      $"\nMgcAttack {generatedAdventure.Potency.MgcAttackPotency} MgcDefense {generatedAdventure.Potency.MgcDefensePotency} " +
                                      $"\nCritical {generatedAdventure.Potency.CriticalPotency} Speed {generatedAdventure.Potency.SpeedPotency} Accuracy {generatedAdventure.Potency.AccuracyPotency}");
        }

        [Button]
        private void SimulateTraining()
        {
            _trainingController.SetupTraining("TRN-Warrior");
            var metaData = _advetureMetaDataService.GetAdventureMetaData();
            Debug.Log($"Rank {metaData.Rank}\n Class {metaData.JobClass} \n Level : {metaData.Experience.Level}");
          Debug.Log($"Training Result : " +
                                      $"Health {metaData.Statuses.FinalStatus.Health} " +
                                      $"PysAttack {metaData.Statuses.FinalStatus.PysAttack} PysDefense {metaData.Statuses.FinalStatus.PysDefense} " +
                                      $"MgcAttack {metaData.Statuses.FinalStatus.MgcAttack} MgcDefense {metaData.Statuses.FinalStatus.MgcDefense} " +
                                      $"Critical {metaData.Statuses.FinalStatus.Critical} Speed {metaData.Statuses.FinalStatus.Speed} Accuracy {metaData.Statuses.FinalStatus.Accuracy}");
            Debug.Log($"Efficiency Result : " +
                                     $"Health {metaData.TrainingEfficiency.HealthEfficiency} " +
                                     $"PysAttack {metaData.TrainingEfficiency.PysAttackEfficiency} PysDefense {metaData.TrainingEfficiency.PysDefenseEfficiency} " +
                                     $"MgcAttack {metaData.TrainingEfficiency.MgcAttackEfficiency} MgcDefense {metaData.TrainingEfficiency.MgcDefenseEfficiency} " +
                                     $"Critical {metaData.TrainingEfficiency.CriticalEfficiency} Speed {metaData.TrainingEfficiency.SpeedEfficiency} Accuracy {metaData.TrainingEfficiency.AccuracyEfficiency}");
        }

        [Button]
        private void SimulateRest()
        {
            _trainingService.RestAdvenuture();
            var metaData = _advetureMetaDataService.GetAdventureMetaData();

            Debug.Log($"Rest Result : " +
                                      $"Health {metaData.TrainingEfficiency.HealthEfficiency} " +
                                      $"PysAttack {metaData.TrainingEfficiency.PysAttackEfficiency} PysDefense {metaData.TrainingEfficiency.PysDefenseEfficiency} " +
                                      $"MgcAttack {metaData.TrainingEfficiency.MgcAttackEfficiency} MgcDefense {metaData.TrainingEfficiency.MgcDefenseEfficiency} " +
                                      $"Critical {metaData.TrainingEfficiency.CriticalEfficiency} Speed {metaData.TrainingEfficiency.SpeedEfficiency} Accuracy {metaData.TrainingEfficiency.AccuracyEfficiency}");
        }
    }
}
