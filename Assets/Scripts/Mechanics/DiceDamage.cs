using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanics
{
    public class DiceDamage
    {
        public int DiceCount { get; set; }
        public int Modifier { get; set; }

        public DiceDamage(Unit unit)
        {
            DiceCount = unit.DiceCount;
            Modifier = unit.Modifier;
        }

        public int RollDamage()
        {
            int total = 0;
            for (int i = 0; i < DiceCount; i++)
                total += Roll._1d6();
            return total + Modifier;
        }

        public override string ToString()
        {
            string mod = Modifier switch
            {
                > 0 => $"+{Modifier}",
                < 0 => $"{Modifier}",
                _ => ""
            };
            return $"{DiceCount}d{mod}";
        }
    }
}
