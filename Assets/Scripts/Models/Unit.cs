using Assets.Scripts.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public abstract class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Skill Skill { get; set; }
        public int DiceCount { get; set; }
        public int Modifier { get; set; }
        public List<Character>? Characters { get; set; }
    }
}
