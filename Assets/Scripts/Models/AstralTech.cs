using Assets.Scripts.Equipment;
using Assets.Scripts.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class AstralTech : Unit
    {
        public DamageType DamageType { get; set; }
        public AstralTechEffect Effect { get; set; }
        public bool IsOffensive { get; set; }
        public StatusEffect StatusEffect { get; set; }
        public int Accuracy { get; set; }
        public int Range { get; set; }
        public int TurnCount { get; set; }
        public int TurnCountMax { get; set; }
        public int StaminaCost { get; set; }
        public int IntelligenceRequirement { get; set; }
        public int Radius { get; set; }
        public int Cost { get; set; }
        public TargetArea TargetArea { get; set; }
    }
}
