using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Patterns
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        [Header("Formation")] public float formationSpread = 0.3f;

        [Header("Stack")] 
        public int width = 4;
        public int length = 10;

        [Header("UnitMovement")] 
        public float unitSideMovementSensitivity = 10f;
        public float unitSideMovementLerpSpeed = 5f;
        public float unitForwardSpeed = 10f;
    }
}