using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Character
{

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Species Species { get; set; }
        public int Level { get; set; }
        public int PowerLevel { get; set; }
        public List<SkillModel> Skills { get; set; } = new();
        public AttributeScore AttributeScore { get; set; }
        public int AttributePoints { get; set; }
        public int SkillPoints { get; set; }
        public int? WeaponId { get; set; }
        public WeaponModel? Weapon { get; set; }
        public List<AstralTech> AstralTech { get; set; } = new();
        public int? ArmorId { get; set; }
        public ArmorModel? Armor { get; set; }
        public int? ShieldId { get; set; }
        public ShieldModel? Shield { get; set; }
        public int? SquadId { get; set; }
        public SquadModel? Squad { get; set; }
}
