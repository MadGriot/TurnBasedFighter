using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.CharacterSheets
{
    public static class NewCharacter
    {
        public static Character GenerateLeonama()
        {
            List<SkillModel> skills = new()
            {
                new SkillModel
                {
                    Level = 3,
                    Skill = Mechanics.Skill.BallisticWeapons,

                },
                new SkillModel
                {
                    Level = 2,
                    Skill = Mechanics.Skill.MeleeWeapons,
                }
            };
            Character character = new Character()
            {
                FirstName = "Leonama",
                LastName = "Samax",
                Level = 51,
                PowerLevel = 75,
                Species = Species.Sutharian,
                AttributeScore = new AttributeScore()
                {
                    BasicLift = 28,
                    BasicMove = 13,
                    Constitution = 23,
                    Dexterity = 20,
                    Dodge = 14,
                    Encumbrance = Mechanics.Encumbrance.None,
                    MinHP = 49,
                    HP = 49,
                    Intelligence = 15,
                    Stamina = 43,
                    MinStamina = 43,
                    Perception = 17,
                    Speed = 10.75M,
                    Strength = 29,
                    Wisdom = 14,
                },
                Weapon = new WeaponModel()
                {
                    Name = "Tauriko T17",
                    DiceCount = 2,
                    Accuracy = 2,
                    Range = 20,
                    WeaponWeight = 2,
                    AmmoWeight = 0.7M,
                    RoF = 3,
                    MaxAmmo = 20,
                    Bulk = -1,
                    Cost = 550,
                    Modifier = 1
                },
                Armor = new ArmorModel()
                {
                    Name = "Great Armor",
                    DamageResistance = 5,
                    Cost = 120000,
                    Weight = 10,
                },
                Shield = new ShieldModel()
                {
                    Name = "Gashius 2",
                    MinSP = 90,
                    MaxSP = 90,
                    SPCost = 10,
                    Cost = 770,
                }
            };
            character.Skills.AddRange(skills);
            return character;
        }

        public static Character GenerateCorduka()
        {
            List<SkillModel> skills = new()
            {
                new SkillModel
                {
                    Level = 5,
                    Skill = Mechanics.Skill.BallisticWeapons,

                },
                new SkillModel
                {
                    Level = 3,
                    Skill = Mechanics.Skill.MeleeWeapons,
                }
            };
            Character character = new Character()
            {
                FirstName = "Corduka",
                LastName = "Fulguma",
                Level = 1,
                PowerLevel = 75,
                Species = Species.Sutharian,
                AttributeScore = new AttributeScore()
                {
                    BasicLift = 20,
                    BasicMove = 6,
                    Constitution = 11,
                    Dexterity = 13,
                    Dodge = 9,
                    Encumbrance = Mechanics.Encumbrance.None,
                    MinHP = 30,
                    HP = 30,
                    Intelligence = 12,
                    Stamina = 31,
                    MinStamina = 31,
                    Perception = 12,
                    Speed = 6.0M,
                    Strength = 10,
                    Wisdom = 10,
                },
                Weapon = new WeaponModel()
                {
                    Name = "Mossofara 680",
                    DiceCount = 4,
                    Accuracy = 2,
                    Range = 15,
                    WeaponWeight = 12,
                    Skill = Mechanics.Skill.BallisticWeapons,
                    AmmoWeight = 2,
                    RoF = 3,
                    MaxAmmo = 7,
                    STRRequirement = 9,
                    Bulk = -5,
                    Cost = 940,
                    Modifier = 10
                },
                Armor = new ArmorModel()
                {
                    Name = "Iron Armor",
                    DamageResistance = 2,
                    Cost = 120000,
                    Weight = 10,
                },
                Shield = new ShieldModel()
                {
                    Name = "Gitupis 17",
                    MinSP = 180,
                    MaxSP = 180,
                    SPCost = 20,
                    Cost = 810,
                }
            };
            character.Skills.AddRange(skills);
            return character;
        }
        public static Character GenerateEnjingos()
        {
            List<SkillModel> skills = new()
            {
                new SkillModel
                {
                    Level = 5,
                    Skill = Mechanics.Skill.BallisticWeapons,

                },
                new SkillModel
                {
                    Level = 3,
                    Skill = Mechanics.Skill.MeleeWeapons,
                }
            };

            Character character = new Character()
            {
                FirstName = "Enjingos",
                LastName = "Shokoaxum",
                Level = 1,
                PowerLevel = 75,
                Species = Species.Sutharian,

                AttributeScore = new AttributeScore()
                {
                    BasicLift = 20,
                    BasicMove = 6,
                    Constitution = 11,
                    Dexterity = 13,
                    Dodge = 9,
                    Encumbrance = Mechanics.Encumbrance.None,
                    MinHP = 30,
                    HP = 30,
                    Intelligence = 12,
                    Stamina = 31,
                    MinStamina = 31,
                    Perception = 12,
                    Speed = 6.0M,
                    Strength = 10,
                    Wisdom = 10,
                },
                Weapon = new WeaponModel()
                {
                    Name = "Sainbimo",
                    DiceCount = 7,
                    Accuracy = 2,
                    Range = 25,
                    WeaponWeight = 11,
                    Skill = Mechanics.Skill.BallisticWeapons,
                    AmmoWeight = 1.7m,
                    RoF = 10,
                    MaxAmmo = 20,
                    STRRequirement = 9,
                    Bulk = -5,
                    Cost = 870,
                    Modifier = 0
                },
                Armor = new ArmorModel()
                {
                    Name = "Iron Armor",
                    DamageResistance = 2,
                    Cost = 120000,
                    Weight = 10,
                },
                Shield = new ShieldModel()
                {
                    Name = "Gashius 2",
                    MinSP = 90,
                    MaxSP = 90,
                    SPCost = 10,
                    Cost = 770,
                }
            };
            character.Skills.AddRange(skills);
            return character;
        }

        public static Character GenerateZukori()
        {
            List<SkillModel> skills = new()
            {
                new SkillModel
                {
                    Level = 5,
                    Skill = Mechanics.Skill.BallisticWeapons,

                },
                new SkillModel
                {
                    Level = 3,
                    Skill = Mechanics.Skill.MartialArts,
                }
            };
            Character character = new Character()
            {
                FirstName = "Zukori",
                LastName = "Ofikonzo",
                Level = 1,
                PowerLevel = 75,
                Species = Species.Sutharian,
                AttributeScore = new AttributeScore()
                {
                    BasicLift = 20,
                    BasicMove = 6,
                    Constitution = 11,
                    Dexterity = 13,
                    Dodge = 9,
                    Encumbrance = Mechanics.Encumbrance.None,
                    MinHP = 30,
                    HP = 30,
                    Intelligence = 12,
                    Stamina = 31,
                    MinStamina = 31,
                    Perception = 12,
                    Speed = 6.0M,
                    Strength = 10,
                    Wisdom = 10,
                },
                Weapon = new WeaponModel()
                {
                    Name = "Ultimate Knuckles",
                    DiceCount = 5,
                    Accuracy = 2,
                    Range = 15,
                    WeaponWeight = 12,
                    Skill = Mechanics.Skill.MartialArts,
                    AmmoWeight = 2,
                    RoF = 3,
                    MaxAmmo = 7,
                    STRRequirement = 9,
                    Bulk = -5,
                    Cost = 940,
                    Modifier = 10
                },
                Armor = new ArmorModel()
                {
                    Name = "Iron Armor",
                    DamageResistance = 2,
                    Cost = 120000,
                    Weight = 10,
                },
                Shield = new ShieldModel()
                {
                    Name = "Magutum",
                    MinSP = 45,
                    MaxSP = 45,
                    SPCost = 5,
                    Cost = 555,
                }
            };
            character.Skills.AddRange(skills);
            return character;
        }
    }
}
