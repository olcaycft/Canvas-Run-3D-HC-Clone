using System;
using UnityEngine;

namespace Game.Scripts.MiniGame
{
    public class Finish : MonoBehaviour
    {
        public static event Action FinishGameObserver;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                FinishGameObserver?.Invoke();
            }
        }
    }
}