using System;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField]private int diamond, gold;

        private void OnEnable()
        {
            diamond = PlayerPrefs.GetInt("DiamondCount", 0);
            gold = PlayerPrefs.GetInt("GoldCount", 0);
        }

        public void IncreaseDiamond(int diamondCount)
        {
            diamond += diamondCount;
            PlayerPrefs.SetInt("DiamondCount",diamond);
        }

        public void IncreaseGold(int goldCount)
        {
            gold += goldCount;
            PlayerPrefs.SetInt("GoldCount",gold);
        }

        public void StartCurrentLevel()
        {
        }

        public void Won()
        {
        }

        public void Failed()
        {
        }
    }
}