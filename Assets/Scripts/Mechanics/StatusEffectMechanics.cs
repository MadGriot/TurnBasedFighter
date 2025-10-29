using Assets.Scripts.Equipment;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanics
{
    public static class StatusEffectMechanics
    {
        public static ResistanceManager ResistanceManager { get; set; } = new();
        public static int StatusEffectDamage(List<StatusEffectRecord> statusEffectRecords, DamageType damageType, int damage)
        {
            foreach (StatusEffectRecord statusEffectRecord in statusEffectRecords)
            {
                switch (statusEffectRecord.StatusEffect)
                {
                    case StatusEffect.None:
                        break;
                    case StatusEffect.BurnEffect:
                        if (damageType.Equals(DamageType.Burning) || damage.Equals(DamageType.Chilling))
                        {
                            damage = Convert.ToInt32(damage - (damage * statusEffectRecord.StatusEffectStrength));
                        }
                        if (damage.Equals(DamageType.Drenching))
                        {
                            damage = Convert.ToInt32(damage + (damage * statusEffectRecord.StatusEffectStrength));
                        }
                        break;
                    case StatusEffect.ChillEffect:
                        if (damageType.Equals(DamageType.Chilling))
                        {
                            damage = Convert.ToInt32(damage - (damage * statusEffectRecord.StatusEffectStrength));

                        }
                        if (damageType.Equals(DamageType.Burning))
                        {
                            damage = Convert.ToInt32(damage + (damage * statusEffectRecord.StatusEffectStrength));
                        }
                        break;
                    case StatusEffect.DrenchEffect:
                        if (damageType.Equals(DamageType.Drenching) || damage.Equals(DamageType.Burning))
                        {
                            damage = Convert.ToInt32(damage - (damage * statusEffectRecord.StatusEffectStrength));

                        }
                        if (damageType.Equals(DamageType.Shocking))
                        {
                            damage = Convert.ToInt32(damage + (damage * statusEffectRecord.StatusEffectStrength));

                        }
                        break;
                    case StatusEffect.ShockEffect:
                        if (damageType.Equals(DamageType.Shocking))
                        {
                            damage = Convert.ToInt32(damage - (damage * statusEffectRecord.StatusEffectStrength));

                        }
                        if (damageType.Equals(DamageType.Gravity))
                        {
                            damage = Convert.ToInt32(damage + (damage * statusEffectRecord.StatusEffectStrength));

                        }
                        break;
                }
            }
            return damage;
        }
    }
}
