using Assets.Scripts.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManeuver : BaseManeuver
{


    private float timer = 0.25f;
    protected void Start()
    {
        Name = "Dodge";
        ManeuverPointCost = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive) return;
        float deltaTime = Time.deltaTime;

        if (timer <= 0f)
        {
            if (Actor.DefensiveStatus != DefensiveStatus.Dodge)
            {
                Actor.DefensiveStatus = DefensiveStatus.Dodge;
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
        if (Actor.DefensiveStatus != DefensiveStatus.None) return false;
        if (ManeuverPointCost <= Actor.ManueverPoints)
        {
            return true;
        }
        return false;
    }
}
