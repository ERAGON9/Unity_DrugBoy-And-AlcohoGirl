using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LevelsArray : Singleton<LevelsArray>
    {
        [Header("Levels Collection")]
        public List<GameObject> LevelsCollection;
    }
}
