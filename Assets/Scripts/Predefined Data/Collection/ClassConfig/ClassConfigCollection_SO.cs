using SotongStudio.SharedData.PredefinedData;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.Trainee.Shared.Predifined.ClassConfig
{
    [CreateAssetMenu(fileName = "ClassConfigCollection", menuName = "Predefined Data/Class Config/Collection")]
    [RegisterAs(typeof(PredefinedCollection<ClassConfig_SO>))]
    public class ClassConfigCollection_SO : PredefinedCollection<ClassConfig_SO>
    {
    
    }
}
