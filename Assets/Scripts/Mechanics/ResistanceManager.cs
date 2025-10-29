using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanics
{
    public class ResistanceManager
    {
        public int AddResistanceModifiers(List<StatusEffectRecord> statusEffectRecords, int damageResistance)
        {
            int currentDamageResistance = damageResistance;
            foreach (StatusEffectRecord statusEffectRecord in statusEffectRecords)
            {
                switch (statusEffectRecord.StatusEffect)
                {
                    case StatusEffect.DamageResistance:
                        currentDamageResistance += (int)statusEffectRecord.StatusEffectStrength;
                        break;
                }
            }
            return currentDamageResistance;
        }
    }
}
