using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActorManeuverSystemUI : MonoBehaviour
{
    [SerializeField] private Transform maneuverButtonPrefab;
    [SerializeField] private Transform maneuverButtonContainerTransform;
    void Start()
    {
        ActorActionSystem2D.Instance.OnSelectedActorChanged += ActorActionSystem2D_OnSelectedActorChanged;
        CreateActorManeuverButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateActorManeuverButtons()
    {
        foreach (Transform buttonTransform in maneuverButtonContainerTransform)
        {
            Destroy(buttonTransform.gameObject);
        }
        Actor selectedActor = ActorActionSystem2D.Instance.GetSelectedActor();

        foreach (BaseManeuver baseManeuver in selectedActor.BaseManeuvers)
        {
            Instantiate(maneuverButtonPrefab, maneuverButtonContainerTransform);
        }
    }

    private void ActorActionSystem2D_OnSelectedActorChanged(object sender, EventArgs e)
    {
        CreateActorManeuverButtons();
    }
}
