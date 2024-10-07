using UnityEngine;

namespace GameLogic
{
    public class LevelsArray : Singleton<LevelsArray>
    {
        [Header("Levels Collection")]
        public GameObject[] LevelsCollection;
    }
}
