using System;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Interactables
{
    public class InteractableBase : MonoBehaviour
    {
        [SerializeField] protected InteractableType baseInteractableType;

        protected virtual void OnTriggerEnter(Collider other)
        {
            /*if (other.gameObject.CompareTag("Player"))
            {
                DoPlayerAction();
            }
            */
        }

        protected virtual void DoPlayerAction()
        {
            InteractableManager.Instance.SetInteractable(baseInteractableType);
        }
    }
}
