using System;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Unit
{
    public class UnitColliderSize : MonoBehaviour
    {
        private void OnEnable()
        {
            StackManager.WidthChangedObserver += ChangeSize;
        }

        private void OnDestroy()
        {
            StackManager.WidthChangedObserver -= ChangeSize;
        }

        private void ChangeSize(int width)
        {
            var scale = transform.lossyScale;
            scale.x = width * 0.25f;
            transform.localScale = scale;
        }
    }
}
