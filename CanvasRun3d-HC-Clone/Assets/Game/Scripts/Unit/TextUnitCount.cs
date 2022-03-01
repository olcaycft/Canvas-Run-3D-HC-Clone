using System;
using Game.Scripts.Managers;
using Game.Scripts.MiniGame;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class TextUnitCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI unitText;

        private void OnEnable()
        {
            StackManager.ChangeUnitCountTextObserver += ChangeUnitText;

            MiniGameController.PlinkoMiniGameStartObserver += DisableText;
            MiniGameController.ImpulseMiniGameStartObserver += DisableText;
            MiniGameController.FinishGameObserver += DisableText;
        }

        private void OnDestroy()
        {
            StackManager.ChangeUnitCountTextObserver -= ChangeUnitText;
            
            MiniGameController.PlinkoMiniGameStartObserver -= DisableText;
            MiniGameController.ImpulseMiniGameStartObserver -= DisableText;
            MiniGameController.FinishGameObserver -= DisableText;
        }


        private void ChangeUnitText(int length, int width)
        {
            unitText.text = (length * width).ToString();
        }

        private void DisableText()
        {
            unitText.enabled = false;
        }
    }
}