using Assets.Scripts.Mechanics;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ShieldManeuver : BaseManeuver
{
    private float timer = 0.25f;


    void Start()
    {
        Name = "Shield";
        ManeuverPointCost = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive) return;
        float deltaTime = Time.deltaTime;

        if (timer <= 0f)
        {
            Actor actor = GetComponent<Actor>();
            if (actor.DefensiveStatus != DefensiveStatus.Block)
            {
                actor.DefensiveStatus = DefensiveStatus.Block;
                actor.Character.Shield.MinSP -= actor.Character.Shield.SPCost;

            }
            ManeuverComplete();
            timer = 1f;
        }
        timer -= deltaTime;
    }

    public override void ActivateManeuver(Action onActionComplete)
    {

        ManeuverStart(onActionComplete);
    }

    public override bool ManeuverValidation()
    {
        Actor actor = GetComponent<Actor>();
        ShieldModel shield = actor.Character.Shield;
        if (actor.DefensiveStatus != DefensiveStatus.None)
        {
            ValidationErrorMessage = "You can only do one defensive maneuver per turn!";
            return false;
        }
        if (ManeuverPointCost <= actor.ManueverPoints)
        {
            if (shield == null)
            {
                ValidationErrorMessage = "You do not have a shield equipped!";
                return false;
            }
            if (shield.MinSP >= shield.SPCost)
            {
                return true;
            }
            else
            {
                ValidationErrorMessage = "Not enough SP!";
                return false;
            }
        }
        ValidationErrorMessage = "Not enough MP!";
        return false;
    }
}
