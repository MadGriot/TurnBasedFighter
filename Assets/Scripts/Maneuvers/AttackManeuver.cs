using Assets.Scripts.Mechanics;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class AttackManeuver : BaseManeuver
{

    private enum AttackState
    {
        Ready,
        Attacking,
        Cooloff,
    }
    private WeaponModel weapon;
    private AttackState attackState;
    private float stateTimer;
    private Actor targetActor;
    private bool canAttack;
    private DiceDamage diceDamage;
    protected void Start()
    {
        Name = "Attack";
        ManeuverPointCost = 1;
        IsOffensive = true;
        //weapon = Actor.Character.Weapon;
        //diceDamage = new DiceDamage(weapon);
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsActive) return;

        stateTimer -= Time.deltaTime;
        switch (attackState)
        {
            case AttackState.Ready:
                if (stateTimer <= 0f)
                {
                    attackState = AttackState.Attacking;
                    stateTimer = 1.0f;
                }
                break;
            case AttackState.Attacking:
                //Attack Animation
                if (stateTimer <= 0f)
                {
                    if (canAttack)
                    {
                        Attack();
                        canAttack = false;
                    }
                    attackState = AttackState.Cooloff;
                    stateTimer = 0.5f;
                }
                break;
            case AttackState.Cooloff:
                //End Animation;
                if (stateTimer <= 0f)
                {
                    ManeuverComplete();
                }
                break;
        }
    }
    private void Attack()
    {
        bool hitTarget = false;
        SkillModel skill = null;
        int rollUnderNumber;
        int rollNumber;
        Character character = Actor.Character;
        if (character.Skills.Any(s => s.Skill == weapon.Skill))
        {
            skill = character.Skills
                .First(s => s.Skill == weapon.Skill);
            rollUnderNumber = SkillMechanics.GetSkillNumber(character.AttributeScore, skill);
            rollNumber = Roll._3d6();
            if (rollNumber < rollUnderNumber && rollNumber != 18)
                hitTarget = true;
            else
                hitTarget = false;
            switch (Actor.DefensiveStatus)
            {
                case DefensiveStatus.None:
                    break;
                case DefensiveStatus.Dodge:
                    rollNumber = character.AttributeScore.Dodge;
                    rollNumber = Roll._3d6();
                    if (rollNumber < rollUnderNumber && rollNumber != 18)
                        hitTarget = true;
                    else
                        hitTarget = false;
                    break;
            }


        }
        else
        {
            rollUnderNumber = SkillMechanics.GetDefaultSkillNumber(character.AttributeScore, weapon.Skill);
            rollNumber = Roll._3d6();
            if (rollNumber < rollUnderNumber && rollNumber != 18)
                hitTarget = true;
            else
                hitTarget = false;
        }
        if (hitTarget)
        {
            int damage = diceDamage.RollDamage();
            targetActor.Damage(damage);
        }
        else
        {

        }
    }
    public override void ActivateManeuver(Action onActionComplete)
    {
        ManeuverStart(onActionComplete);
        targetActor = ActorActionSystem2D.Instance.TurnQueue.First(x => x.IsEnemy == true);
        attackState = AttackState.Ready;
        stateTimer = 1f;

        canAttack = true;
    }
}
