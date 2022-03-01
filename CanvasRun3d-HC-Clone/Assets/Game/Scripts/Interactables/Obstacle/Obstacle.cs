using System;
using UnityEngine;

namespace Game.Scripts.Interactables.Obstacle
{
    public class Obstacle : InteractableBase
    {
        /*protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                base.DoPlayerAction();
            }
            
        }*/
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                base.DoPlayerAction();
            }
        }
    }
}
