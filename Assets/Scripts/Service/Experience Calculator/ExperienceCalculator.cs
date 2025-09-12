using UnityEngine;

namespace SotongStudio.Trainee.Service.ExperienceCalculator
{
    public static class ExperienceCalculator
    {
        private static ushort _levelUpExperience = 1000;
        public static IExperienceCalculateResult CalculateExperience(ushort currentExperience, ushort obtainedExperience)
        {
            var sumExperience = currentExperience + obtainedExperience;

            if (sumExperience < _levelUpExperience)
            {
                return new ExperienceCalculateResult(0, (ushort)sumExperience);
            }

            ushort tempHoldExp = (ushort)sumExperience;
            ushort getLevelAmount = 0;

            while (tempHoldExp >= _levelUpExperience)
            {
                tempHoldExp -= _levelUpExperience;
                getLevelAmount++;

                Debug.Log($"Calculate Result 1 : {tempHoldExp}");

                tempHoldExp = (ushort)(tempHoldExp * 0.85f);
                Debug.Log($"Calculate Result 2 : {tempHoldExp}");
            }

            return new ExperienceCalculateResult(getLevelAmount, tempHoldExp);
        }
    }
}

