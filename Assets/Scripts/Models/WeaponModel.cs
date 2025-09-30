using Assets.Scripts.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class WeaponModel : Unit
    {
        public WeaponType WeaponType { get; set; }
        public DamageType DamageType { get; set; }
        public WeaponClass WeaponClass { get; set; }
        public int Accuracy { get; set; }
        public int Range { get; set; }
        public decimal WeaponWeight { get; set; }
        public decimal AmmoWeight { get; set; }
        public int RoF { get; set; }
        public int MaxAmmo { get; set; }
        public int CurrentAmmo { get; set; }
        public int STRRequirement { get; set; }
        public int Bulk { get; set; }
        public decimal Cost { get; set; }

    }
}
