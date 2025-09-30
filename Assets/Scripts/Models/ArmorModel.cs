using Assets.Scripts.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class ArmorModel : Unit
    {
        public ArmorLocation ArmorLocation { get; set; }
        public int DamageResistance { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }
    }
}
