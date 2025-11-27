using Assets.Scripts.Mechanics;
using Assets.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ShieldManeuver : BaseManeuver
{
    private float timer = 0.25f;

    protected void Awake()
    {
        Name = "Shield";
        ValidationMessage = $"{Actor.Character.FirstName} uses shield";
    }
    void Start()
    {

        ManeuverPointCost = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActorActionSystem2D.Instance.PlayerDead)
            return;
        if (!IsActive) return;
        float deltaTime = Time.deltaTime;

        if (timer <= 0f)
        {
            Actor actor = GetComponent<Actor>();
            if (actor.DefensiveStatus != DefensiveStatus.Block)
            {
                actor.DefensiveStatus = DefensiveStatus.Block;
                actor.ShieldIcon.SetActive(true);
                actor.Character.Shield.MinSP -= actor.Character.Shield.SPCost;
                actor.ShieldBar.value = actor.Character.Shield.MinSP;

            }
            ManeuverComplete();
            timer = 1f;
        }
        timer -= deltaTime;
    }

    public override void ActivateManeuver(Action onActionComplete)
    {
        if (ActorActionSystem2D.Instance.IsPlayerTurn)
            ActorManeuverSystemUI.Instance.playerTurnContainer.GetComponent<TextMeshProUGUI>().text = ValidationMessage;
        else
            ActorManeuverSystemUI.Instance.enemyTurnContainer.GetComponent<TextMeshProUGUI>().text = ValidationMessage;
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
