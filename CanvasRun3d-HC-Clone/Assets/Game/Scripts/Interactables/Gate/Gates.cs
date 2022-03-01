using System;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Interactables.Gate
{
    public class Gates : InteractableBase
    {
        public static event Action PlayerAtGate;
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerAtGate?.Invoke();
                switch (baseInteractableType)
                {
                    case InteractableType.Gate:
                    {
                        var pos = other.gameObject.transform.position;
                        baseInteractableType = pos.x < 0 ? InteractableType.WidthGate : InteractableType.LengthGate;
                        break;
                    }
                }
                gameObject.SetActive(false);
            }
            
            //base.OnTriggerEnter(other);
            base.DoPlayerAction();
        }
    }
}
