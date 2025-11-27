using Assets.Scripts.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DodgeManeuver : BaseManeuver
{


    private float timer = 0.25f;

    protected void Awake()
    {
        Name = "Dodge";
        ValidationMessage = $"{Actor.Character.FirstName} uses dodge";
    }
    protected void Start()
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
            if (Actor.DefensiveStatus != DefensiveStatus.Dodge)
            {
                Actor.DefensiveStatus = DefensiveStatus.Dodge;
                Actor.DodgeIcon.SetActive(true);
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
        if (Actor.DefensiveStatus != DefensiveStatus.None) return false;
        if (ManeuverPointCost <= Actor.ManueverPoints)
        {
            return true;
        }
        return false;
    }
}
