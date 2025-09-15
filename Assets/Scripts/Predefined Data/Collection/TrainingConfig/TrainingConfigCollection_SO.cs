using SotongStudio.SharedData.PredefinedData;
using SotongStudio.VContainer;
using UnityEngine;

namespace SotongStudio.Trainee.Shared.Predifined.Training
{
    [RegisterAs(typeof(PredefinedCollection<TrainingConfig_SO>))]
    [CreateAssetMenu(fileName = "Trainig Config Collection", menuName = "Predefined Data/Training Config/Collection")]
    public class TrainingConfigCollection_SO : PredefinedCollection<TrainingConfig_SO>
    {
    
    }
}
