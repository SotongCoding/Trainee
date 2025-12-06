using SotongStudio.Trainee.Shared.Adventure.Data;
using SotongStudio.Trainee.Shared.Adventure.Status;
using Unity.VisualScripting;
using UnityEngine;

namespace SotongStudio.Trainee
{
    public static class AdventureMetaDataServiceExtension
    {
        public static AdventureTrainingStatus GetTrainingStatus(this AdventureMetaData metaData)
        {
            return metaData.Statuses.TrainingStatus;
        }
    }
}
