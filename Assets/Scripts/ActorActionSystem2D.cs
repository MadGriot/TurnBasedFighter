using Assets.Scripts.Mechanics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ActorActionSystem2D : MonoBehaviour
{

    public static ActorActionSystem2D Instance { get; private set; }
    private const float MAX_TIMER_DISPLAY = 1f;
    private float UITimer;
    private bool hasRemovedDisplayNumber = true;

    [SerializeField] private Actor Actor;
    [SerializeField] private Actor BossActor;
    public event EventHandler OnSelectedActorChanged;
    public event EventHandler OnSelectedManeuverChanged;
    public event EventHandler OnManeuverStarted;
    public event EventHandler OnEncounterStarted;
    public event EventHandler<MpUsedEventArgs> OnMpUsed;
    public event EventHandler OnTurnEnded;


    internal bool maneuverSelected;
    internal List<Actor> TurnQueue { get; set; } = new();

    internal BaseManeuver SelectedManeuver { get; set; }
    internal bool IsBusy { get; set; }
    internal bool IsPlayerTurn { get; set; } = true;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        TurnQueue.Add(Actor);
        TurnQueue.Add(BossActor);
        SetSelectedActor(Actor);
        StartCombat(Actor);


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnEnded()
    {
        Actor actor = TurnQueue[0];
        TurnQueue.RemoveAt(0);
        actor.ResetManeuverPoints();
        actor.DefensiveStatus = DefensiveStatus.None;
        actor.ResetDefensiveStatus();
        TurnQueue.Add(actor);
        IsPlayerTurn = !actor.IsEnemy;
        SetSelectedActor(actor);
        OnTurnEnded?.Invoke(this, EventArgs.Empty);
    }
    private void SetBusy() => IsBusy = true;
    private void ClearBusy() => IsBusy = false;

    public Actor GetSelectedActor() => Actor;
    private void SetSelectedActor(Actor actor)
    {

        Actor.actorSelected = false;

        Actor = actor;
        SelectedManeuver = actor.GetComponent<AttackManeuver>();


        OnSelectedActorChanged?.Invoke(this, EventArgs.Empty);
    }
    private void StartCombat(Actor actor)
    {
        if (actor.IsEnemy && IsPlayerTurn != false)
        {
            IsPlayerTurn = false;
        }
        else
        {
            TurnQueue.RemoveAt(0);
            TurnQueue.Add(actor);
        }
    }
    public void HandleSelectedManeuver()
    {

            if (Actor.CanDoManeuver(SelectedManeuver))
            {
                SetBusy();
                SelectedManeuver.ActivateManeuver(ClearBusy);
                OnMpUsed?.Invoke(this, new MpUsedEventArgs(SelectedManeuver.ManeuverPointCost));
                OnManeuverStarted?.Invoke(this, EventArgs.Empty);
            }
       
    }
    public class MpUsedEventArgs : EventArgs
    {
        public int Amount { get; }

        public MpUsedEventArgs(int amount)
        {
            Amount = amount;
        }
    }
}
