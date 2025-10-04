using Assets.Scripts.Mechanics;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Actor : MonoBehaviour
{
    const int MAX_MANEUVER_POINTS = 3;
    internal int ManueverPoints = MAX_MANEUVER_POINTS;

    internal ActorActionSystem2D ActorActionSystem;
    public bool IsEnemy;
    internal Character Character;
    internal BaseManeuver[] BaseManeuvers;
    internal bool DidOffensiveManeuver;
    internal bool DidDefensiveManeuver;
    internal List<StatusEffect> StatusEffects;
    internal DefensiveStatus DefensiveStatus = DefensiveStatus.None;
    internal bool actorSelected;
    // private DamageSystem damageSystem;

    private void Awake()
    {
        BaseManeuvers = GetComponents<BaseManeuver>();

    }
    void Start()
    {
        //damageSystem = GetComponent<DamageSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool TryToDoManeuver(BaseManeuver baseManeuver)
    {
        AstralTechManeuver astralTechManeuver;
        if (CanDoManeuver(baseManeuver))
        {
            if (baseManeuver.IsOffensive)
            {
                if (baseManeuver.IsAstralTech)
                {
                    astralTechManeuver = (AstralTechManeuver)baseManeuver;

                }

                DidOffensiveManeuver = true;

            }
            if (!baseManeuver.IsOffensive)
            {
                if (DefensiveStatus != DefensiveStatus.None) return false;
                DidDefensiveManeuver = true;
            }
            return true;
        }
        else return false;
    }

    public bool CanDoManeuver(BaseManeuver baseManeuver)
    {
        return baseManeuver.ManeuverValidation();
    }

    public void Damage(int damage)
    {
        //damageSystem.Damage(damage);

    }
}
