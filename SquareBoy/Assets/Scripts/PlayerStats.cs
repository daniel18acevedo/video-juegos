using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class PlayerStats
    {
        public static int TotalMelons { get; set; }
        public static int LifesLeft { get; set; } = 3;

        public static void AddMelons(int melons)
        {
            TotalMelons += melons;
        }

        public static void ResetLifes()
        {
            LifesLeft = 3;
        }

        public static void RestLife()
        {
            LifesLeft -= 1;
        }

        public static void ResetMelons()
        {
            TotalMelons = 0;
        }

        public static void ResetStats()
        {
            ResetMelons();
            ResetLifes();
        }
    }
}
