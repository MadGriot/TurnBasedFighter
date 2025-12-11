using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.Rendering.DebugUI;

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
    private BehaviorTree tree;
    private BehaviorTree tree2;
    private BehaviorSelector treeSelector;

    internal AttackManeuver attackManeuver { get; private set;  }
    internal ShieldManeuver shieldManeuver { get; private set; }
    internal DodgeManeuver dodgeManeuver { get; private set; }
    void Start()
    {
        state = State.WaitingForEnemyTurn;
        ActorActionSystem2D.Instance.OnSelectedActorChanged += ActorActionSystem2D_OnSelectedActorChanged;
        attackManeuver = GetComponent<AttackManeuver>();
        shieldManeuver = GetComponent<ShieldManeuver>();
        dodgeManeuver = GetComponent<DodgeManeuver>();
        tree = new();
        tree2 = new();
        treeSelector = new("Tree Selector");
        SetUpBehaviorTreeSequence(tree);
        SetUpBehaviorTreeSequence2(tree2);
        treeSelector.AddChild(tree);
        treeSelector.AddChild(tree2);
    }

    // Update is called once per frame
    void Update()
    {
        if (ActorActionSystem2D.Instance.IsPlayerTurn)
            return;
        if (ActorActionSystem2D.Instance.PlayerDead)
            return;
        switch (state)
        {
            case State.WaitingForEnemyTurn:
                break;
            case State.TakingTurn:
                treeSelector.Process();
                if (treeSelector.SelectedSequence.Process())
                {
                    state = State.Busy;
                }
                else
                {
                    state = State.WaitingForEnemyTurn;
                }
                break;
            case State.Busy:
                break;
        }
        float deltaTime = Time.deltaTime;

    }
    private void SetStateTakingTurn()
    {
        timer = 1.5f;
        state = State.TakingTurn;
    }

    private void ActorActionSystem2D_OnSelectedActorChanged(object sender, EventArgs e)
    {
        if (!ActorActionSystem2D.Instance.IsPlayerTurn)
        {
            state = State.TakingTurn;
            timer = 2f;

        }
    }

    private bool TryTakeEnemyAIManeuver(Action onEnemyAIManeuverComplete, BaseManeuver baseManeuver)
    {
        baseManeuver.ActivateManeuver(onEnemyAIManeuverComplete);
        return true;
    }

    public void SetUpBehaviorTreeSequence(BehaviorTree tree)
    {
        Actor actor = GetComponent<Actor>();
        BehaviorSequence turnPattern = new("Turn Pattern");
        BehaviorLeaf attack = new("Attack Target", () => TryTakeEnemyAIManeuver(SetStateTakingTurn, attackManeuver), () => actor.CanDoManeuver(attackManeuver));
        BehaviorLeaf attack2 = new("Attack Target", () => TryTakeEnemyAIManeuver(SetStateTakingTurn, attackManeuver), () => actor.CanDoManeuver(attackManeuver));
        BehaviorLeaf shield = new("Using Shield", () => TryTakeEnemyAIManeuver(ActorActionSystem2D.Instance.TurnEnded, shieldManeuver), () => actor.CanDoManeuver(shieldManeuver));

        turnPattern.AddChild(attack);
        turnPattern.AddChild(attack2);
        turnPattern.AddChild(shield);
        tree.AddChild(turnPattern);
    }

    public void SetUpBehaviorTreeSequence2(BehaviorTree tree)
    {
        Actor actor = GetComponent<Actor>();
        BehaviorSequence turnPattern = new("Turn Pattern2");
        BehaviorLeaf attack = new("Attack target", () => TryTakeEnemyAIManeuver(SetStateTakingTurn, attackManeuver), () => actor.CanDoManeuver(attackManeuver));
        BehaviorLeaf attack2 = new("Attack target again", () => TryTakeEnemyAIManeuver(SetStateTakingTurn, attackManeuver), () => actor.CanDoManeuver(attackManeuver));
        BehaviorLeaf dodge = new("Attack Target antoher time", () => TryTakeEnemyAIManeuver(ActorActionSystem2D.Instance.TurnEnded, dodgeManeuver), () => actor.CanDoManeuver(dodgeManeuver));

        turnPattern.AddChild(attack);
        turnPattern.AddChild(attack2);
        turnPattern.AddChild(dodge);
        tree.AddChild(turnPattern);

    }
}
