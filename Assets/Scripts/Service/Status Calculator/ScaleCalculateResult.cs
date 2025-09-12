using SotongStudio.Trainee.Shared.Adventure.Status;
using UnityEngine;

namespace SotongStudio.Trainee.Service.StatusCalculator
{
    public static class StatGrowthConfig
    {
        [Header("S-Curve Parameters")]
        public const int Midpoint = 50;
        public const float Steepness = 0.15f;
        public const int MaxPoint = 380;

        public const float InitialGrowthRate = 4f;
        public const float ReductionFactor = 0.0025f;
    }

    public class ScaleCalculateResult : IAdventureStatus
    {
        public ushort Health { get; private set; }
        public ushort PysAttack { get; private set; }
        public ushort PysDefense { get; private set; }
        public ushort MgcAttack { get; private set; }
        public ushort MgcDefense { get; private set; }
        public ushort Critical { get; private set; }
        public ushort Speed { get; private set; }
        public ushort Accuracy { get; private set; }

        public static ScaleCalculateResult CreateNewScaleResult(IAdventureStatus inputStatus, ushort level)
        {
            ushort health = CalculateStat2(inputStatus.Health, level);

            ushort pysAttack = CalculateStat2(inputStatus.PysAttack, level);
            ushort psyDefense = CalculateStat2(inputStatus.PysDefense, level);

            ushort mgcAttack = CalculateStat2(inputStatus.MgcAttack, level);
            ushort mgcDefense = CalculateStat2(inputStatus.MgcDefense, level);

            ushort critical = CalculateStat2(inputStatus.Critical, level);
            ushort speed = CalculateStat2(inputStatus.Speed, level);
            ushort accuracy = CalculateStat2(inputStatus.Accuracy, level);

            return new ScaleCalculateResult(health, pysAttack, psyDefense, mgcAttack, mgcDefense, critical, speed, accuracy);
        }

        private static ushort CalculateStat2(ushort baseValue, ushort level)
        {
            if (level < 1) level = 1;
            if (level > 99) level = 99;

            // Rumus deret geometri untuk menghitung total pertumbuhan
            // S = a * (1 - r^(n-1)) / (1 - r)
            int n = (level - 1); // Jumlah level yang mengalami pertumbuhan (dari level 2 hingga level saat ini)
            float a = StatGrowthConfig.InitialGrowthRate; // Pertumbuhan awal
            float r = 1 - StatGrowthConfig.ReductionFactor; // Faktor pengurangan

            float totalGrowth = a * (1 - Mathf.Pow(r, n + baseValue)) / (1 - r);

            // Hitung nilai stat akhir
            float statValue = baseValue + totalGrowth;


            return (ushort)statValue;
        }


        public ScaleCalculateResult(ushort health,
                                    ushort pysAttack, ushort pysDefense,

                                    ushort mgcAttack, ushort mgcDefense,

                                    ushort critical, ushort speed, ushort accuracy)
        {
            Health = health;
            PysAttack = pysAttack;
            PysDefense = pysDefense;
            MgcAttack = mgcAttack;
            MgcDefense = mgcDefense;
            Critical = critical;
            Speed = speed;
            Accuracy = accuracy;
        }
    }
}
