using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class BaseManeuver : MonoBehaviour
{
    public Actor Actor;
    internal ActorActionSystem2D ActorActionSystem { get; set; }
    public string ValidationErrorMessage { get; protected set; } = "Can not do maneuver";
    public string Name { get; set; }
    internal bool IsActive;
    internal bool IsOffensive;
    internal int ManeuverPointCost;
    internal bool IsAstralTech;
    protected Action OnActionComplete;


    public BaseManeuver()
    {

    }
    protected void Awake()
    {
        Name = "Manuever";

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public abstract void ActivateManeuver(Action onActionComplete);
    public virtual bool ManeuverValidation()
    {
        
        if (ManeuverPointCost <= Actor.ManueverPoints)
        {
            return true;
        }
        return false;
    }

    protected void ManeuverStart(Action onActionComplete)
    {
        IsActive = true;
        OnActionComplete = onActionComplete;
    }

    protected void ManeuverComplete()
    {
        IsActive = false;
        Actor.ManueverPoints -= ManeuverPointCost;
        OnActionComplete();
    }
}
