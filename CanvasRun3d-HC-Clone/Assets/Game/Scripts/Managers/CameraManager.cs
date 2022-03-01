using System;
using System.Collections;
using Cinemachine;
using Game.Scripts.Interactables.Gate;
using Game.Scripts.MiniGame;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts.Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera gameRunCam;
        [SerializeField] private CinemachineVirtualCamera gateRunCam;
        [SerializeField] private CinemachineVirtualCamera plinkoCam;

        private void OnEnable()
        {
            Gates.PlayerAtGate += EnableGateCam;
            MiniGameController.PlinkoMiniGameStartObserver += EnablePlinkoCam;
        }

        private void OnDestroy()
        {
            Gates.PlayerAtGate -= EnableGateCam;
            MiniGameController.PlinkoMiniGameStartObserver -= EnablePlinkoCam;
        }

        private void EnableGateCam()
        {
            StopAllCoroutines();
            gameRunCam.enabled = false;
            gateRunCam.enabled = true;
            StartCoroutine(nameof(AfterGateRoutine));
        }

        private IEnumerator AfterGateRoutine()
        {
            yield return new WaitForSeconds(1f);
            gameRunCam.enabled = true;
            gateRunCam.enabled = false;
        }

        private void EnablePlinkoCam()
        {
            gameRunCam.enabled = false;
            gateRunCam.enabled = false;
            plinkoCam.enabled = true;
        }
        
    }
}
