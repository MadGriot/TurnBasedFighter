using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class BaseManeuver : MonoBehaviour
{
    public Actor Actor { get; set; }
    internal ActorActionSystem2D ActorActionSystem { get; set; }

    public string Name { get; protected set; } = "Maneuver";
    internal bool isActive;
    internal bool IsOffensive;
    internal int ManeuverPointCost;
    internal bool IsAstralTech;
    protected Action OnActionComplete;


    public BaseManeuver()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual bool ManeuverValidation()
    {
        
        if (ManeuverPointCost <= Actor.ManueverPoints)
        {
            return true;
        }
        return false;
    }
}
