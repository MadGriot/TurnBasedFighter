using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Mechanics
{
    public static class SkillMechanics
    {
        public static int GetSkillCost(int level)
        {
            if (level == 0) return 1;
            if (level == 1) return 2;
            if (level == 2) return 4;

            return 4 + (level - 2) * 4;
        }
        public static int GetSkillNumber(AttributeScore attributeScore, SkillModel skillModel)
        {
            return skillModel.Skill switch
            {
                Skill.Acrobatics => attributeScore.Dexterity + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Armory => attributeScore.Intelligence + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Artillery => attributeScore.Dexterity + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.AstralTech => ((attributeScore.Intelligence + attributeScore.Wisdom) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.BallisticWeapons => ((attributeScore.Dexterity + attributeScore.Perception) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.ComputerKnowledge => attributeScore.Intelligence + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Diplomacy => ((attributeScore.Intelligence + attributeScore.Wisdom) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.EnergyWeapons => ((attributeScore.Dexterity + attributeScore.Perception) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Engineering => attributeScore.Intelligence + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Explosives => ((attributeScore.Intelligence + attributeScore.Dexterity) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.FirstAid => ((attributeScore.Intelligence + attributeScore.Perception) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.HeavyWeapons => ((attributeScore.Dexterity + attributeScore.Strength) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Leadership => ((attributeScore.Intelligence + attributeScore.Wisdom) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Lockpicking => ((attributeScore.Intelligence + attributeScore.Dexterity) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.MartialArts => ((attributeScore.Strength + attributeScore.Dexterity) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.MeleeWeapons => ((attributeScore.Strength + attributeScore.Dexterity) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Merchant => attributeScore.Wisdom + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Pickpocket => attributeScore.Dexterity + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Piloting => ((attributeScore.Intelligence + attributeScore.Perception) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Science => attributeScore.Intelligence + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Stealth => ((attributeScore.Dexterity + attributeScore.Perception) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
                Skill.Throwing => ((attributeScore.Dexterity + attributeScore.Strength) / 2) + GetDifficultyModifier(skillModel.Level, GetSkillDifficulty(skillModel.Skill)),
            };
        }
        public static int GetDifficultyModifier(int level, SkillDifficulty skillDifficulty)
        {

            return skillDifficulty switch
            {
                SkillDifficulty.Easy => level - 1,
                SkillDifficulty.Average => level - 2,
                SkillDifficulty.Hard => level - 3,
                SkillDifficulty.VeryHard => level - 4,
                _ => throw new ArgumentOutOfRangeException(nameof(skillDifficulty), "Invalid difficulty.")
            };
        }


        public static int GetDefaultSkillNumber(AttributeScore attributeScore, Skill skill)
        {
            return skill switch
            {
                Skill.Acrobatics => attributeScore.Dexterity - 6,
                Skill.Armory => attributeScore.Intelligence - 5,
                Skill.Artillery => attributeScore.Dexterity - 5,
                Skill.AstralTech => ((attributeScore.Intelligence + attributeScore.Wisdom) / 2) - 7,
                Skill.BallisticWeapons => ((attributeScore.Dexterity + attributeScore.Perception) / 2) - 4,
                Skill.ComputerKnowledge => attributeScore.Intelligence - 4,
                Skill.Diplomacy => ((attributeScore.Intelligence + attributeScore.Wisdom) / 2) - 6,
                Skill.EnergyWeapons => ((attributeScore.Dexterity + attributeScore.Perception) / 2) - 4,
                Skill.Engineering => attributeScore.Intelligence - 6,
                Skill.Explosives => ((attributeScore.Intelligence + attributeScore.Dexterity) / 2) - 5,
                Skill.FirstAid => ((attributeScore.Intelligence + attributeScore.Perception) / 2) - 4,
                Skill.HeavyWeapons => ((attributeScore.Dexterity + attributeScore.Strength) / 2) - 4,
                Skill.Leadership => ((attributeScore.Intelligence + attributeScore.Wisdom) / 2) - 5,
                Skill.Lockpicking => ((attributeScore.Intelligence + attributeScore.Dexterity) / 2) - 5,
                Skill.MartialArts => ((attributeScore.Strength + attributeScore.Dexterity) / 2) - 2,
                Skill.MeleeWeapons => ((attributeScore.Strength + attributeScore.Dexterity) / 2) - 2,
                Skill.Merchant => attributeScore.Wisdom - 5,
                Skill.Pickpocket => attributeScore.Dexterity - 6,
                Skill.Piloting => ((attributeScore.Intelligence + attributeScore.Perception) / 2) - 6,
                Skill.Science => attributeScore.Intelligence - 6,
                Skill.Stealth => ((attributeScore.Dexterity + attributeScore.Perception) / 2) - 4,
                Skill.Throwing => ((attributeScore.Dexterity + attributeScore.Strength) / 2) - 3,
            };
        }
        public static SkillDifficulty GetSkillDifficulty(Skill skill)
        {
            return skill switch
            {
                Skill.Acrobatics => SkillDifficulty.Hard,
                Skill.Armory => SkillDifficulty.Average,
                Skill.Artillery => SkillDifficulty.Average,
                Skill.AstralTech => SkillDifficulty.VeryHard,
                Skill.BallisticWeapons => SkillDifficulty.Easy,
                Skill.ComputerKnowledge => SkillDifficulty.Easy,
                Skill.Diplomacy => SkillDifficulty.Hard,
                Skill.EnergyWeapons => SkillDifficulty.Easy,
                Skill.Engineering => SkillDifficulty.Hard,
                Skill.Explosives => SkillDifficulty.Average,
                Skill.FirstAid => SkillDifficulty.Easy,
                Skill.HeavyWeapons => SkillDifficulty.Easy,
                Skill.Leadership => SkillDifficulty.Average,
                Skill.Lockpicking => SkillDifficulty.Average,
                Skill.MartialArts => SkillDifficulty.Average,
                Skill.MeleeWeapons => SkillDifficulty.Average,
                Skill.Merchant => SkillDifficulty.Average,
                Skill.Pickpocket => SkillDifficulty.Hard,
                Skill.Piloting => SkillDifficulty.Average,
                Skill.Science => SkillDifficulty.VeryHard,
                Skill.Stealth => SkillDifficulty.Easy,
                Skill.Throwing => SkillDifficulty.Average,
            };
        }
    }
}
