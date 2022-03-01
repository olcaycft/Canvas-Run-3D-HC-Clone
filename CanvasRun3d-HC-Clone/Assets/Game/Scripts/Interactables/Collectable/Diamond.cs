using UnityEngine;
namespace Game.Scripts.Interactables.Collectable
{
    public class Diamond : InteractableBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                base.DoPlayerAction();
                gameObject.SetActive(false);
            }
            
        }
    }
}
