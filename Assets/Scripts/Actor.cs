using Assets.Scripts.Equipment;
using Assets.Scripts.Globals;
using Assets.Scripts.Mechanics;
using Assets.Scripts.Models;
using Assets.Scripts.Models.CharacterSheets;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Actor : MonoBehaviour
{
    const int MAX_MANEUVER_POINTS = 3;
    internal int ManueverPoints = MAX_MANEUVER_POINTS;
    [SerializeField] public GameObject ShieldIcon;
    [SerializeField] public GameObject DodgeIcon;

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
    public Slider ShieldBar;

    private void Awake()
    {
        BaseManeuvers = GetComponents<BaseManeuver>();
        switch (CharacterName)
        {
            case "Leonama":
                Character = NewCharacter.GenerateLeonama();
                break;
            case "Corduka":
                Character = NewCharacter.GenerateCorduka();
                break;
            case "Enjingos":
                Character = NewCharacter.GenerateEnjingos();
                break;
            case "Zukori":
                Character = NewCharacter.GenerateZukori();
                break;
        }

    }
    void Start()
    {
        damageSystem = GetComponent<DamageSystem>();
        damageSystem.OnKill += DamageSystem_OnKill;

        if (HealthBar != null && ShieldBar != null)
        {
            SetBattleHud();
        }

    }
    public void ResetDefensiveStatus()
    {
        ShieldIcon.SetActive(false);
        DodgeIcon.SetActive(false);
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

    public void SetBattleHud()
    {
        HealthBar.maxValue = Character.AttributeScore.HP;
        HealthBar.value = Character.AttributeScore.MinHP;
        ShieldBar.maxValue = Character.Shield.MaxSP;
        ShieldBar.value = Character.Shield.MinSP;
        ResetDefensiveStatus();
    }
    public void Damage(int damage, DamageType damageType)
    {
        damageSystem.Damage(damage, StatusEffects, damageType);
        HealthBar.value = Character.AttributeScore.MinHP;
        ShieldBar.value = Character.Shield.MinSP;
    }
    private void DamageSystem_OnKill(object sender, EventArgs e)
    {
        if (IsEnemy)
        {
            
            switch (Character.FirstName)
            {
                case "Corduka":
                    SequenceSystem.CordukaDead = true;
                    break;
                case "Enjingos":
                    SequenceSystem.EnjingosDead = true;
                    break;
                case "Zukori":
                    SequenceSystem.ZukoriDead = true;
                    break;
            }
            SequenceSystem.EndCombat();
        }
        else
        {
            ActorActionSystem2D.Instance.PlayerDead = true;
            GameObject.FindGameObjectWithTag("Music").GetComponent<BackgroundMusic>().StopMusic();

        }
    }
    public void ResetManeuverPoints() => ManueverPoints = MAX_MANEUVER_POINTS;
}
