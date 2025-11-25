using Assets.Scripts.Equipment;
using Assets.Scripts.Mechanics;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DamageSystem : MonoBehaviour
{
    internal Character Character { get; set; }
    internal Actor Actor { get; set; }
    public event EventHandler OnKill;
    int totalDamage = 0;
    void Start()
    {
        Character = GetComponent<Actor>().Character;
        Actor = GetComponent<Actor>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Damage(int damageAmount, List<StatusEffectRecord> statusEffectRecords, DamageType damageType)
    {
        int totalResistance;
        switch (Actor.DefensiveStatus)
        {
            case DefensiveStatus.None:
            case DefensiveStatus.Dodge:
                totalDamage = StatusEffectMechanics.StatusEffectDamage(statusEffectRecords, damageType, damageAmount);
                if (totalDamage > 0)
                {
                    totalResistance = StatusEffectMechanics.ResistanceManager.AddResistanceModifiers(statusEffectRecords, Character.Armor.DamageResistance);
                    totalDamage = Math.Max(0, totalDamage - totalResistance);
                }
                Character.AttributeScore.MinHP -= totalDamage;
                break;

            case DefensiveStatus.Block:
                int remainingDamage = damageAmount;
                int shieldAbsorbed = 0;
                if (Character.Shield.MinSP > 0)
                {
                    shieldAbsorbed = Math.Min(Character.Shield.MinSP, remainingDamage);
                    Character.Shield.MinSP -= shieldAbsorbed;
                    remainingDamage -= shieldAbsorbed;
                }

                if (remainingDamage > 0)
                {
                    Character.AttributeScore.MinHP = Math.Max(0, Character.AttributeScore.MinHP - remainingDamage);

                }
                else
                {
                }
                break;
        }

        if (Character.AttributeScore.MinHP <= 0)
        {
            OnKill?.Invoke(this, EventArgs.Empty);
        }


    }
}
