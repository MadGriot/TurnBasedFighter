using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpSystem : MonoBehaviour
{
    public Transform mpBlock; // Parent object containing MP icons

    private List<Image> mpElements = new();
    void Start()
    {
        for (int i = 3; i >= 1; i--)
        {
            Transform mpTransform = mpBlock.Find($"Mp{i}");
            if (mpTransform != null)
            {
                Image mpImage = mpTransform.GetComponent<Image>();
                if (mpImage != null)
                    mpElements.Add(mpImage);
            }
        }

        ActorActionSystem2D.Instance.OnMpUsed += ActorActionSystem2D_OnMpUsed;
        ActorActionSystem2D.Instance.OnTurnEnded += ActorActionSystem2D_OnTurnEnded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetMpDisplay()
    {
        foreach (var mpImage in mpElements)
        {
            mpImage.enabled = true;
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (ActorActionSystem2D.Instance != null)
        {
            ActorActionSystem2D.Instance.OnMpUsed -= ActorActionSystem2D_OnMpUsed;
            ActorActionSystem2D.Instance.OnTurnEnded -= ActorActionSystem2D_OnTurnEnded;
        }
    }
    private void SubtractMpDisplay(int mp)
    {
        for (int i = 0; i < mpElements.Count && mp > 0; i++)
        {
            if (mpElements[i].enabled)
            {
                mpElements[i].enabled = false;
                mp--;
            }
        }
    }
    private void ActorActionSystem2D_OnTurnEnded(object sender, EventArgs e)
    {
        ResetMpDisplay();
    }

    private void ActorActionSystem2D_OnMpUsed(object sender, ActorActionSystem2D.MpUsedEventArgs e)
    {
        SubtractMpDisplay(e.Amount);
    }
}
