using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LevelsManagement : Singleton<LevelsManagement>
    {
        [Header("Levels Collection")]
        public List<GameObject> LevelsCollection;
    }
}
