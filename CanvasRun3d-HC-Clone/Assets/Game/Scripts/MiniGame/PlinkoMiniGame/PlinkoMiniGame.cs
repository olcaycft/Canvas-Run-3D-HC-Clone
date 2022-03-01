using System;
using System.Collections;
using Game.Scripts.Patterns;
using UnityEngine;

namespace Game.Scripts.MiniGame
{
    public class PlinkoMiniGame : MonoBehaviour
    {
        private Vector3 pos;
        private Quaternion rot;
        private bool changePos;

        public static event Action ChangeUnitRigidBodyObserver;
        private void OnEnable()
        {
            MiniGameController.PlinkoMiniGameStartObserver += PlinkoGame;
        }

        private void OnDestroy()
        {
            MiniGameController.PlinkoMiniGameStartObserver -= PlinkoGame;
        }

        private void Update()
        {
            if (!changePos) return;
            ChangePosition();
        }

        private void PlinkoGame()
        {
            pos = transform.position;
            rot = Quaternion.identity;
            pos.x = 0f;
            pos.z += 10f;
            pos.y += 15f;
            rot = Quaternion.Euler(90f, 0f, 0f);
            changePos = true;
            Invoke(nameof(ChangePosState), 2f);
        }


        private void ChangePosition()
        {
            transform.position = Vector3.Lerp(transform.position, pos, 2f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 2f * Time.deltaTime);
        }

        private void ChangePosState()
        {
            changePos = false;
            ChangeUnitRigidBodyObserver?.Invoke();
            //ObjectPooler.Instance.SetRb("Unit");
        }
    }
}