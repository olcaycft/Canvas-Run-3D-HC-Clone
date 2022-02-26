using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public class FormationMovement : MonoBehaviour,IOnUnitSpawn
    {
        [SerializeField] private GameObject stackObjPrefab;
        [SerializeField] private Transform parent;

        private List<GameObject> StackParts = new List<GameObject>();

        private List<Vector3> PositionHistory = new List<Vector3>();

        //private int gap =>Mathf.RoundToInt(parent.GetComponent<Renderer>().bounds.size.z)+1;
        private int gap =15;
        private int length;

        private void OnEnable()
        {
            StackManager.LengthChangedObserver += ChangeLength;
        }

        private void OnDestroy()
        {
            StackManager.LengthChangedObserver -= ChangeLength;
        }

        private void Update()
        {
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
                var point = PositionHistory[Mathf.Min(index*gap, PositionHistory.Count - 1)];
                //point.z = PositionHistory[Mathf.Min(index, PositionHistory.Count - 1)].z * 0.3f;
                stackObj.transform.position = Vector3.Lerp(stackObj.transform.position, point, 0.5f);
                //stackObj.transform.position = point;
                index++;
            }
        }

        private void GrowStack()
        {
            GameObject body = Instantiate(stackObjPrefab, parent);
            StackParts.Add(body);
        }

        private void Kill(int num) //its will be replace with obj pool later
        {
            for (int i = 0; i < num; i++)
            {
                var unit = StackParts.Last();
                StackParts.Remove(unit);
                Destroy(unit.gameObject);
            }
        }

        public void OnUnitSpawn()
        {
            length = GameManager.Instance.GetLength();
        }
    }
}