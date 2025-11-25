using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Globals
{
    public static class SequenceSystem
    {
        public static GameObject PlayerObject { get; set; }
        public static bool InCombat {get; set;}
        public static Vector3 CharacterPosition { get; set; } = new Vector3(-7.5f, -6.0f, 0);
        public static bool CordukaDead { get; set; }

        public static void EndCombat()
        {
            SceneManager.LoadScene(0);
            InCombat = false;
        }
    }
}
