using System;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Interactables.Gate
{
    public class Gates : InteractableBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
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
