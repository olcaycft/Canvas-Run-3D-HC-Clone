using UnityEngine;

namespace Game.Scripts.Interactables.MiniGames.PlinkoMiniGame
{
    public class PlinkoMiniGameInteractable : InteractableBase
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Unit"))
            {
                other.gameObject.transform.SetParent(null);
                other.transform.position=Vector3.zero;
                other.gameObject.SetActive(false);
            }
            //base.OnTriggerEnter(other);
            base.DoPlayerAction();
        }
    }
}
