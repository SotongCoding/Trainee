using NaughtyAttributes;
using SotongStudio.Trainee.Service.AdventureGenerator;
using SotongStudio.Trainee.Shared.Adventure.Data;
using UnityEngine;
using VContainer;

namespace SotongStudio.Trainee
{
    public class TestingB :MonoBehaviour
    {

        [SerializeField] private AdventureGenerator _adventureGenerator;
        [SerializeField] private IAdventureMetaDataService _advetureMetaDataService;
        private IObjectResolver _resolver;

        [Inject]
        private void Inject(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        [Button]
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
            
            Debug.Log($"Status : \n Level : {generatedAdventure.Statuses.MainStatus.Level}" +
                      $"\n Health : {generatedAdventure.Statuses.MainStatus.Health}" +
                      $"\n" +
                      $"\n Class : {generatedAdventure.JobClass}" +
                      $"\n Rank : {generatedAdventure.Rank}");
        }
    }
}
