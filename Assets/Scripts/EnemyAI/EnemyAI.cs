using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        WaitingForEnemyTurn,
        TakingTurn,
        Busy,
    }
    private State state;
    private float timer;
    void Start()
    {
        state = State.WaitingForEnemyTurn;
        ActorActionSystem2D.Instance.OnSelectedActorChanged += ActorActionSystem2D_OnSelectedActorChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActorActionSystem2D.Instance.IsPlayerTurn)
            return;
        float deltaTime = Time.deltaTime;
        timer -= deltaTime;
        if (timer <= 0f)
        {
            ActorActionSystem2D.Instance.TurnEnded();
        }
    }

    private void ActorActionSystem2D_OnSelectedActorChanged(object sender, EventArgs e)
    {
        if (!ActorActionSystem2D.Instance.IsPlayerTurn)
        {
            state = State.TakingTurn;
            timer = 2f;

        }
    }
}
