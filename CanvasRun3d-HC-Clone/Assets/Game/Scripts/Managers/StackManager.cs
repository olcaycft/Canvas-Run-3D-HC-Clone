using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Managers
{
    /// <summary>
    /// This class temporariy this logic will replace or expand with interactableGates
    /// </summary>
    public class StackManager : MonoSingleton<StackManager>
    {
        [SerializeField] private int width = 4, length = 10;
        [SerializeField] private int tempWidth, tempLength, newWidth, newLength;

        public static event Action<int> WidthChangedObserver;
        public static event Action<int> LengthChangedObserver;

        public static event Action<int, int> ChangeLengthTextObserver;
        public static event Action<int, int> ChangeWidthTextObserver;

        private void Awake()
        {
            tempWidth = width;
            tempLength = length;

            LengthChangedObserver?.Invoke(tempLength);
            WidthChangedObserver?.Invoke(tempWidth);

            CalculateNewLength();
            CalculateNewWidth();
        }

        private void Update()
        {
            SetStackCount();
        }

        public void SetStackCount()
        {
            if (tempLength != length)
            {
                tempLength = length;
                LengthChangedObserver?.Invoke(tempLength);
            }

            if (tempWidth != width)
            {
                tempWidth = width;
                WidthChangedObserver?.Invoke(tempWidth);
            }
        }

        private void CalculateNewLength()
        {
            var randomLengthInterval = Random.Range(1, length - 1);
            newLength = Random.value < 0.25f ? -randomLengthInterval :+randomLengthInterval;
            Debug.Log(newLength);
            ChangeLengthTextObserver?.Invoke(newLength, width);
        }

        private void CalculateNewWidth()
        {
            var randomWidthInterval = Random.Range(1, width);
            newWidth = Random.value < 0.25f ? -randomWidthInterval : randomWidthInterval;
            ChangeWidthTextObserver?.Invoke(length, newWidth);
        }

        public void SetNewLength()
        {
                length += newLength;

            CalculateNewLength();
            CalculateNewWidth();
        }

        public void SetNewWidth()
        {
                width += newWidth;
            CalculateNewLength();
            CalculateNewWidth();
        }


        public int GetLength()
        {
            return length;
        }

        public int GetWidth()
        {
            return width;
        }
    }
}