using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private int width, length;


        private void OnEnable()
        {
            StackManager.WidthChangedObserver += SetNewWidth;
            StackManager.LengthChangedObserver += SetNewLength;
        }

        private void OnDestroy()
        {
            StackManager.WidthChangedObserver -= SetNewWidth;
            StackManager.LengthChangedObserver -= SetNewLength;
        }

        private void SetNewWidth(int width)
        {
            this.width = width;
        }

        private void SetNewLength(int length)
        {
            this.length = length;
        }

        public int GetLength()
        {
            return length;
        }
    }
}