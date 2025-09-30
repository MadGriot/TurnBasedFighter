using Assets.Scripts.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class SkillModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public Skill Skill { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;

    }
}
