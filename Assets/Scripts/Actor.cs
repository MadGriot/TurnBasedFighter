using Assets.Scripts.Equipment;
using Assets.Scripts.Mechanics;
using Assets.Scripts.Models;
using Assets.Scripts.Models.CharacterSheets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    const int MAX_MANEUVER_POINTS = 3;
    internal int ManueverPoints = MAX_MANEUVER_POINTS;

    [SerializeField]
    private string CharacterName;
    public bool IsEnemy;
    internal Character Character;
    internal BaseManeuver[] BaseManeuvers;
    internal bool DidOffensiveManeuver;
    internal bool DidDefensiveManeuver;
    internal List<StatusEffectRecord> StatusEffects { get; set; } = new();
    internal DefensiveStatus DefensiveStatus = DefensiveStatus.None;
    internal bool actorSelected;
    private DamageSystem damageSystem;
    public Slider HealthBar; 

    private void Awake()
    {
        BaseManeuvers = GetComponents<BaseManeuver>();

    }
    void Start()
    {
        damageSystem = GetComponent<DamageSystem>();

        switch (CharacterName)
        {
            case "Leonama":
                Character = NewCharacter.GenerateLeonama();
                break;
            case "Corduka":
                Character = NewCharacter.GenerateCorduka();
                break;
        }
        HealthBar.maxValue = Character.AttributeScore.HP;
        HealthBar.value = Character.AttributeScore.MinHP;
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

    public void Damage(int damage, DamageType damageType)
    {
        damageSystem.Damage(damage, StatusEffects, damageType);
        HealthBar.value = Character.AttributeScore.MinHP;
    }

    public void ResetManeuverPoints() => ManueverPoints = MAX_MANEUVER_POINTS;
}
