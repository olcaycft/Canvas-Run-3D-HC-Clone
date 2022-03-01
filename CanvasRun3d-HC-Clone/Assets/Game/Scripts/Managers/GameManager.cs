using System;
using Game.Scripts.MiniGame;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private int diamond, gold, interactedBallCount, totalBallCount;

        public static event Action GameFinishedObserver;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

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
            UIManager.Instance.TotalGoldText();
            interactedBallCount++;
            if (interactedBallCount == totalBallCount)
            {
                Won();
            }
        }

        public void StartCurrentLevel()
        {
            interactedBallCount = 0;
            UIManager.Instance.StartGame();
        }

        public void Won()
        {
            //StackManager.Instance.ResetWidthAndLenght();
            UIManager.Instance.Win();
            GameFinishedObserver?.Invoke();
        }

        public void Failed()
        {
            //StackManager.Instance.ResetWidthAndLenght();
            UIManager.Instance.Fail();
            GameFinishedObserver?.Invoke();
        }

        private void GetTotalBallCount()
        {
            totalBallCount = StackManager.Instance.GetLength() * StackManager.Instance.GetWidth();
        }
    }
}