using System;
using Game.Scripts.Patterns;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Scripts.Managers
{
    /// <summary>
    /// This class temporariy this logic will replace or expand with interactableGates
    /// </summary>
    public class StackManager : MonoSingleton<StackManager>
    {
        private int _width => SettingsManager.GameSettings.width;
        private int _length => SettingsManager.GameSettings.length;
        private int width, length, tempWidth, tempLength, newWidth, newLength;

        public static event Action<int> WidthChangedObserver;
        public static event Action<int> LengthChangedObserver;

        public static event Action<int, int> ChangeLengthTextObserver;
        public static event Action<int, int> ChangeWidthTextObserver;
        public static event Action<int, int> ChangeUnitCountTextObserver;


        private void Awake()
        {
            width = _width;
            length = _length;
            
            tempWidth = width;
            tempLength = length;

            LengthChangedObserver?.Invoke(tempLength);
            WidthChangedObserver?.Invoke(tempWidth);
            ChangeUnitCountTextObserver?.Invoke(tempLength, tempWidth);
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

            if (width == 0 || length == 0)
            {
                GameManager.Instance.Failed();
            }

            ChangeUnitCountTextObserver?.Invoke(tempLength, tempWidth);
        }

        private void CalculateNewLength()
        {
            var randomLengthInterval = Random.Range(1, length - 1);
            newLength = Random.value < 0.25f ? -randomLengthInterval : +randomLengthInterval;
            ChangeLengthTextObserver?.Invoke(newLength, width);
        }

        private void CalculateNewWidth()
        {
            var randomWidthInterval = Random.Range(1, width);
            newWidth = Random.value < 0.25f ? -randomWidthInterval : randomWidthInterval;
            ChangeWidthTextObserver?.Invoke(length, newWidth);
        }

        public void DecreaseWidth()
        {
            width -= 1;
            CalculateNewLength();
            CalculateNewWidth();
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