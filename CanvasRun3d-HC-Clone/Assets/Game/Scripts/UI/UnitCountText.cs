using Game.Scripts.Managers;
using Game.Scripts.MiniGame;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI
{
    public class UnitCountText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI unitText;

        private void OnEnable()
        {
            StackManager.ChangeUnitCountTextObserver += ChangeUnitText;

            GameStateController.PlinkoMiniGameStartObserver += DisableText;
            GameStateController.ImpulseMiniGameStartObserver += DisableText;
            GameStateController.FinishGameObserver += DisableText;
        }

        private void OnDestroy()
        {
            StackManager.ChangeUnitCountTextObserver -= ChangeUnitText;
            
            GameStateController.PlinkoMiniGameStartObserver -= DisableText;
            GameStateController.ImpulseMiniGameStartObserver -= DisableText;
            GameStateController.FinishGameObserver -= DisableText;
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