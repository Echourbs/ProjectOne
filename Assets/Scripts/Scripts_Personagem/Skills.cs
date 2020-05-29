using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTE
{
    [CreateAssetMenu(menuName = "RPG Generator/Player/Create Skill")]
    public class Skills : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
        public int LevelNeeded;
        public int XPNeeded;

        public List<PlayerAttributes> Attributes = new List<PlayerAttributes>();

    }

}

