using System;
using UnityEngine;

namespace Game.Scripts.Patterns
{
    public class SettingsManager : MonoSingleton<SettingsManager>
    {
        [SerializeField] private GameSettings settings;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static GameSettings GameSettings => Instance.settings;
    }
}