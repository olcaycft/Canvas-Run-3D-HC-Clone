using System;
using UnityEngine;

namespace Game.Scripts.MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        public static event Action PlinkoMiniGameObserver;
        public static event Action ImpulseMiniGameObserver;
        public static event Action FinishGameObserver;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PlinkoMiniGame"))
            {
                PlinkoMiniGameObserver?.Invoke();
            }
            else if (other.gameObject.CompareTag("ImpulseMiniGame"))
            {
                ImpulseMiniGameObserver?.Invoke();
            }
            else if (other.gameObject.CompareTag("Finish"))
            {
                FinishGameObserver?.Invoke();
            }
        }
    }
}