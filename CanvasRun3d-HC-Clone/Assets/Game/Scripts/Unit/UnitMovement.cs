using System;
using Game.Scripts.Managers;
using UnityEngine;
using Game.Scripts.MiniGame;

namespace Game.Scripts.Unit
{
    public class UnitMovement : MonoBehaviour
    {
        private Vector2 inputDrag;
        private Vector2 previousMousePosition;

        [SerializeField] private Transform sideMovementRoot;
        [SerializeField] private Transform stackRightLimit;
        [SerializeField] private Transform stackLeftLimit;
        private float stackRightLimitX;

        [SerializeField]private float stackLeftLimitX;

        //private float sideMovementSensitivity => SettingsManager.GameSettings.playerSideMovementSensitivity;
        //private float sideMovementLerpSpeed => SettingsManager.GameSettings.playerSideMovementLerpSpeed;
        //private float forwardSpeed => SettingsManager.GameSettings.playerForwardSpeed;
        private float sideMovementSensitivity = 10f;
        private float sideMovementLerpSpeed = 5f;
        private float forwardSpeed = 10f;
        private float rotationSpeed = 5f;

        private float sideMovementTarget;

        /*private bool isGameStart;
        private bool isLevelFinish;*/

        private bool isFinish;
        private bool isPlinko;
        private bool isImpulse;

        private int tempWidth;

        private void OnEnable()
        {
            stackRightLimitX = stackRightLimit.localPosition.x;
            stackLeftLimitX = stackLeftLimit.localPosition.x;
            tempWidth = StackManager.Instance.GetWidth();
            StackManager.WidthChangedObserver += SetLeftRightLimits;
            MiniGameController.FinishGameObserver += ChangeFinishState;
            MiniGameController.PlinkoMiniGameObserver += ChangePlinkoState;
            MiniGameController.ImpulseMiniGameObserver += ChangeImpulseState;

        }

        private void OnDestroy()
        {
            StackManager.WidthChangedObserver -= SetLeftRightLimits;
            MiniGameController.FinishGameObserver -= ChangeFinishState;
            MiniGameController.PlinkoMiniGameObserver -= ChangePlinkoState;
            MiniGameController.ImpulseMiniGameObserver -= ChangeImpulseState;
        }

        private Vector2 mousePositionCM
        {
            get
            {
                Vector2 pixels = Input.mousePosition;
                var inches = pixels / Screen.dpi;
                var centimeters = inches * 2.54f;

                return centimeters;
            }
        }

        private void Update()
        {
            if (isFinish) return;
            HandleInput();
            if (isImpulse) return;
            SideMovement();
            /*if (!isGameStart)
            {
                return;
            }*/
            if (isPlinko) return;
            ForwardMovement();
            
            
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                previousMousePosition = mousePositionCM;
            }

            if (Input.GetMouseButton(0))
            {
                var deltaMouse = mousePositionCM - previousMousePosition;
                inputDrag = deltaMouse;
                previousMousePosition = mousePositionCM;

                /*if (isGameStart || (inputDrag.x == 0 && inputDrag.y == 0)) return;
                isGameStart = true;
                GameManager.Instance.StartThisLevel();*/
            }
            else
            {
                inputDrag = Vector2.zero;
            }
        }

        private void SideMovement()
        {
            //change players sidemovement root's local position, not a world.
            sideMovementTarget += inputDrag.x * sideMovementSensitivity;
            sideMovementTarget = Mathf.Clamp(sideMovementTarget, stackLeftLimitX, stackRightLimitX);
            var localPos = sideMovementRoot.localPosition;
            localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sideMovementLerpSpeed);
            sideMovementRoot.localPosition = localPos;

            //for rotate players rotation for current direction

            /*var moveDirection = Vector3.forward * 0.5f;
            moveDirection += sideMovementRoot.right * inputDrag.x * sideMovementSensitivity;
            moveDirection.Normalize();
            var targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            sideMovementRoot.rotation = Quaternion.Lerp(sideMovementRoot.rotation, targetRotation, Time.deltaTime * rotationSpeed);*/
        }

        private void ForwardMovement()
        {
            transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
        }

        private void SetLeftRightLimits(int width)
        {
            var half = width / 2;
            if (tempWidth <= width)
            {
                tempWidth = width;
                stackLeftLimitX += half * 0.1f;
                stackRightLimitX -= half * 0.1f;
            }
            else
            {
                tempWidth = width;
                stackLeftLimitX -= half * 0.1f;
                stackRightLimitX += half * 0.1f;
            }
            
            
        }
        
        private void ChangeFinishState()
        {
            isFinish = true;
        }

        private void ChangePlinkoState()
        {
            isPlinko = true;
        }

        private void ChangeImpulseState()
        {
            isImpulse = true;
        }
    }
}