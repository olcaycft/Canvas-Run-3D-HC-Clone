using System;
using UnityEngine;

namespace Game.Scripts.MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        public static event Action PlinkoMiniGameStartObserver;
        public static event Action ImpulseMiniGameStartObserver;
        public static event Action FinishGameObserver;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlinkoMiniGame"))
            {
                PlinkoMiniGameStartObserver?.Invoke();
            }
            else if (other.gameObject.CompareTag("ImpulseMiniGame"))
            {
                ImpulseMiniGameStartObserver?.Invoke();
            }
            else if (other.gameObject.CompareTag("Finish"))
            {
                FinishGameObserver?.Invoke();
            }
        }
    }
}