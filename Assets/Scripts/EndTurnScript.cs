using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndTurnScript : MonoBehaviour
{
    [SerializeField] private Button button;
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            ActorActionSystem2D.Instance.TurnEnded();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
