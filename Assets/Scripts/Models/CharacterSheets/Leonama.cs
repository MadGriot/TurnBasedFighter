using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.CharacterSheets
{
    public static class Leonama
    {
        public static Character GenerateCharacter()
        {
            return new Character()
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
                }
            };
        }
    }
}
