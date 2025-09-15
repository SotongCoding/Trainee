using NaughtyAttributes;
using SotongStudio.Trainee.Gameplay.Training;
using SotongStudio.Trainee.Service.AdventureGenerator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using UnityEditor.SceneManagement;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee
{
    public class TestingB : MonoBehaviour
    {

        [SerializeField] private AdventureGenerator _adventureGenerator;
        [SerializeField] private IAdventureMetaDataService _advetureMetaDataService;
        private IObjectResolver _resolver;
        private ITrainingService _trainingService;

        [Inject]
        private void Inject(IObjectResolver resolver,
                            AdventureGenerator adventureGenerator,
                            IAdventureMetaDataService adventureMetaDataService,
                            ITrainingService trainingService)
        {
            _resolver = resolver;
            _adventureGenerator = adventureGenerator;
            _advetureMetaDataService = adventureMetaDataService;
            _trainingService = trainingService;

        }

        //[Button]
        private void ResolveDI()
        {
            _adventureGenerator = _resolver.Resolve<AdventureGenerator>();
            _advetureMetaDataService = _resolver.Resolve<IAdventureMetaDataService>();
        }

        [Button]
        private void SimulateCreateEnemy()
        {
            var adventure = _adventureGenerator.CreateAdventureMetaData();
            _advetureMetaDataService.SetAdventureData(adventure);

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
            var metaData = _advetureMetaDataService.GetAdventureMetaData();
            _trainingService.DoTraining(metaData, "TRN-Warrior");

            Debug.Log($"Training Result : " +
                                      $"Health {metaData.Statuses.FinalStatus.Health} " +
                                      $"PysAttack {metaData.Statuses.FinalStatus.PysAttack} PysDefense {metaData.Statuses.FinalStatus.PysDefense} " +
                                      $"MgcAttack {metaData.Statuses.FinalStatus.MgcAttack} MgcDefense {metaData.Statuses.FinalStatus.MgcDefense} " +
                                      $"Critical {metaData.Statuses.FinalStatus.Critical} Speed {metaData.Statuses.FinalStatus.Speed} Accuracy {metaData.Statuses.FinalStatus.Accuracy}");
        }
    }
}
