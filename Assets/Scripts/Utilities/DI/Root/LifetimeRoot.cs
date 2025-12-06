using System.Collections.Generic;
using NaughtyAttributes;
using SotongStudio.SharedData.PlayerCollection;
using SotongStudio.SharedData.PredefinedData;
using SotongStudio.Trainee;
using SotongStudio.Trainee.Gameplay.Facility.Training;
using SotongStudio.Utilities.SceneLoader;
using SotongStudio.VContainer;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

namespace SotongStudio.Plugins.DI
{
    public class LifetimeRoot : LifetimeScope
    {
        [SerializeField] private ScriptableObject[] _registerdScriptableObjects;
        [SerializeField] private List<ScriptableObject> _predefinedCollection;
        [SerializeField] private MonoBehaviour[] _gameObject;
        protected override void Configure(IContainerBuilder builder)
        {
            InternalConfigure(builder);

            builder.RegisterPlayerCollection();

            AdditionalRegistration(builder);
        }

        private void InternalConfigure(IContainerBuilder builder)
        {
            foreach (var data in _registerdScriptableObjects)
            {
                VContainerDIInstallerUtils.RegisterScriptable(builder, data);
            }
            foreach (var data in _predefinedCollection)
            {
                VContainerDIInstallerUtils.RegisterScriptable(builder, data);
            }

            VContainerDIInstallerUtils.RegisterMonoBehaviourComponents(builder, _gameObject);
        }

        private static void AdditionalRegistration(IContainerBuilder builder)
        {
            builder.RegisterAdverntureServiceDI();
            builder.RegisterTrainingServiceDI();

            builder.RegisterVillageRootDI();
            builder.RegisterTrainingFacilityRootDI();
            builder.RegisterRecruitRootDI();
        }

        #region Get Predefined Data Helper
#if UNITY_EDITOR
        private class SearchType : ScriptableObject, IPredefinedItem
        {
            public string ItemId => throw new System.NotImplementedException();
        }

        [Button]
        private void GetPredefineCollection()
        {
            var folderPath = Application.dataPath + "/Content/Predefined Collection";
            using var _ = ListPool<string>.Get(out var files);
            files.AddRange(System.IO.Directory.GetFiles(folderPath, "*.asset", System.IO.SearchOption.AllDirectories));
            SpecifiedFile(files);

            _predefinedCollection.Clear();
            foreach (var file in files)
            {
                var filePath = file.Substring(file.IndexOf("Asset"));
                Debug.Log(filePath);
                var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(filePath);

                if (asset != null)
                    _predefinedCollection.Add(asset);

            }
        }

        private void SpecifiedFile( List<string> files)
        {
            using var _ = ListPool<string>.Get(out var tempFiles);
            tempFiles.AddRange(files);

            foreach (var item in tempFiles)
            {
                var parts = item.Split('/', '\\');

                if (!parts[parts.Length-1].Contains("Collection"))
                {
                    files.Remove(item);
                }
            }
        }
#endif
        #endregion
    }
}
