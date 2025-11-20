using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActorManeuverSystemUI : MonoBehaviour
{
    [SerializeField] private Transform maneuverButtonPrefab;
    [SerializeField] private GameObject maneuverButtonContainerTransform;
    [SerializeField] private GameObject playerTurnContainer;
    [SerializeField] private GameObject enemyTurnContainer;
    void Start()
    {
        ActorActionSystem2D.Instance.OnSelectedActorChanged += ActorActionSystem2D_OnSelectedActorChanged;
        CreateActorManeuverButtons();
        SetUIBasedOnTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUIBasedOnTurn()
    {
        if (ActorActionSystem2D.Instance.IsPlayerTurn)
        {

            playerTurnContainer.SetActive(true);
            maneuverButtonContainerTransform.SetActive(true);
            enemyTurnContainer.SetActive(false);
        }
        else
        {
            playerTurnContainer.SetActive(false);
            maneuverButtonContainerTransform.SetActive(false);
            enemyTurnContainer.SetActive(true);
        }

    }
    private void CreateActorManeuverButtons()
    {
        foreach (Transform buttonTransform in maneuverButtonContainerTransform.transform)
        {
            Destroy(buttonTransform.gameObject);
        }
        Actor selectedActor = ActorActionSystem2D.Instance.GetSelectedActor();

        foreach (BaseManeuver baseManeuver in selectedActor.BaseManeuvers)
        {
            Transform actionButtonTransfrom = Instantiate(maneuverButtonPrefab, maneuverButtonContainerTransform.transform);
            ActionButtonUI actionButtonUI = actionButtonTransfrom.GetComponent<ActionButtonUI>();
            actionButtonUI.SetBaseManeuver(baseManeuver);
        }
    }

    private void ActorActionSystem2D_OnSelectedActorChanged(object sender, EventArgs e)
    {
        CreateActorManeuverButtons();
        SetUIBasedOnTurn();
    }
}
