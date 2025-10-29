using Assets.Scripts.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public record StatusEffectRecord
    {
        public StatusEffect StatusEffect { get; set; }
        public float StatusEffectStrength { get; set; }
        public int TurnDuration { get; set; }

        public StatusEffectRecord(StatusEffect statusEffect, float statusEffectStrength, int turnDuration)
        {
            StatusEffect = statusEffect;
            StatusEffectStrength = statusEffectStrength;
            TurnDuration = turnDuration;
        }
    }
}
