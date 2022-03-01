using System;
using Game.Scripts.MiniGame;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private int diamond, gold, interactedBallCount, totalBallCount;

        private void OnEnable()
        {
            diamond = PlayerPrefs.GetInt("DiamondCount", 0);
            gold = PlayerPrefs.GetInt("GoldCount", 0);
            
            MiniGameController.PlinkoMiniGameStartObserver += GetTotalBallCount;
        }

        private void OnDestroy()
        {
            MiniGameController.PlinkoMiniGameStartObserver -= GetTotalBallCount;
        }

        public void IncreaseDiamond(int diamondCount)
        {
            diamond += diamondCount;
            PlayerPrefs.SetInt("DiamondCount", diamond);
        }

        public void IncreaseGold(int goldCount)
        {
            gold += goldCount;
            PlayerPrefs.SetInt("GoldCount", gold);
            interactedBallCount++;
            if (interactedBallCount == totalBallCount)
            {
                Won();
            }
        }

        public void StartCurrentLevel()
        {
            interactedBallCount = 0;
        }

        public void Won()
        {
            Debug.Log("Won");
            StackManager.Instance.ResetWidthAndLenght();
        }

        public void Failed()
        {
            StackManager.Instance.ResetWidthAndLenght();
        }

        private void GetTotalBallCount()
        {
            totalBallCount = StackManager.Instance.GetLength() * StackManager.Instance.GetWidth();
        }
    }
}