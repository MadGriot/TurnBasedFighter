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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void HandleSelectedManeuver()
    {
        if (maneuverSelected)
        {
            if (Actor.CanDoManeuver(SelectedManeuver))
            {
                SetBusy();
                SelectedManeuver.ActivateManeuver(ClearBusy);
                OnMpUsed?.Invoke(this, new MpUsedEventArgs(SelectedManeuver.ManeuverPointCost));
                OnManeuverStarted?.Invoke(this, EventArgs.Empty);
                maneuverSelected = false;
            }
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
