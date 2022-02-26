using System;
using UnityEngine;

namespace Game.Scripts.Managers
{
    /// <summary>
    /// This class temporariy this logic will replace with interactableGates
    /// </summary>
    public class StackManager : MonoBehaviour
    {
        [SerializeField] private int width=4, length=10;
        [SerializeField] private int tempWidth, tempLength;

        public static event Action<int> WidthChangedObserver ;
        public static event Action<int> LengthChangedObserver ;
        private void Awake()
        {
            tempWidth = width;
            tempLength=length;
        
            LengthChangedObserver?.Invoke(tempLength);
            WidthChangedObserver?.Invoke(tempWidth);
        }

        private void Update()
        {
            CheckStackCount();
        }

        private void CheckStackCount()
        {
            if (tempLength != length)
            {
                tempLength = length;
                LengthChangedObserver?.Invoke(tempLength);
            }

            if (tempWidth !=width)
            {
                tempWidth = width;
                WidthChangedObserver?.Invoke(tempWidth);
            }
        }
    }
}
