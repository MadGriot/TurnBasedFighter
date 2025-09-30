using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class ShieldModel : Unit
    {
        public int MinSP { get; set; }
        public int MaxSP { get; set; }
        public int SPCost { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }

    }
}
