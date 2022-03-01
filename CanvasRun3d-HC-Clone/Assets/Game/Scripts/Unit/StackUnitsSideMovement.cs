using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Managers;
using UnityEngine;
using Game.Scripts.MiniGame;
using Game.Scripts.Patterns;

namespace Game.Scripts.Unit
{
    public class StackUnitsSideMovement : MonoBehaviour, IOnUnitSpawn
    {
        
        
        //[SerializeField] private GameObject stackObjPrefab;
        [SerializeField] private Transform parent;

        private List<GameObject> StackParts = new List<GameObject>();

        private List<Vector3> PositionHistory = new List<Vector3>();

        //private int gap =>Mathf.RoundToInt(parent.GetComponent<Renderer>().bounds.size.z)+1;
        private int gap = 5;
        private int length;

        private bool isFinish;
        private bool isPlinko;
        private bool isImpulse;

        private void OnEnable()
        {
            StackManager.LengthChangedObserver += ChangeLength;
            MiniGameController.FinishGameObserver += ChangeFinishState;
            MiniGameController.PlinkoMiniGameObserver += ChangePlinkoState;
            MiniGameController.ImpulseMiniGameObserver += ChangeImpulseState;
            
        }

        private void OnDestroy()
        {
            StackManager.LengthChangedObserver -= ChangeLength;
            MiniGameController.FinishGameObserver -= ChangeFinishState;
            MiniGameController.PlinkoMiniGameObserver -= ChangePlinkoState;
            MiniGameController.ImpulseMiniGameObserver -= ChangeImpulseState;
        }

        private void Update()
        {
            if (isFinish || isPlinko || isImpulse) return;
            StackCount();
            StackMovement();
        }

        private void StackCount()
        {
            if (length > StackParts.Count)
            {
                for (int i = 0; i < length; i++)
                {
                    GrowStack();
                }
            }
            else if (length < StackParts.Count)
            {
                Kill(StackParts.Count - length);
            }
        }

        private void ChangeLength(int length)
        {
            this.length = length;
        }

        private void StackMovement()
        {
            PositionHistory.Insert(0, parent.position);
            var index = 1;
            foreach (var stackObj in StackParts)
            {
                var point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];
                //point.z = PositionHistory[Mathf.Min(index, PositionHistory.Count - 1)].z * 0.3f;
                stackObj.transform.position = Vector3.Lerp(stackObj.transform.position, point, 0.4f);
                //stackObj.transform.position = point;
                index++;
            }
        }

        private void GrowStack()
        {
            //GameObject body = Instantiate(stackObjPrefab, parent);
            GameObject body = ObjectPooler.Instance.SpawnFromPool("Unit",parent.position,parent.rotation);
            body.transform.SetParent(transform);
            StackParts.Add(body);
        }

        private void Kill(int num) //its will be replace with obj pool later
        {
            for (int i = 0; i < num; i++)
            {
                var unit = StackParts.Last();
                StackParts.Remove(unit);
                //Destroy(unit.gameObject);
                unit.transform.SetParent(null);
                unit.transform.position=Vector3.zero;
                unit.SetActive(false);
                
            }
        }

        public void OnUnitSpawn()
        {
            length = StackManager.Instance.GetLength();
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