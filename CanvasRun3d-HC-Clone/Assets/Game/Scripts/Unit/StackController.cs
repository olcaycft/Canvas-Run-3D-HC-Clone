using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class StackController : MonoBehaviour
    {
        [SerializeField] private GameObject stackObjPrefab;
        [SerializeField] private Transform parent;

        private List<GameObject> StackParts = new List<GameObject>();
        private List<Vector3> PositionHistory = new List<Vector3>();
        //private int gap =>Mathf.RoundToInt(parent.GetComponent<Renderer>().bounds.size.z)+1;
        private int gap = 25;

        private void Start()
        {
            StackParts.Add(parent.gameObject);
            for (int i = 0; i < 100; i++)
            {
                GrowStack();
            }
        }

        private void Update()
        {
            StackMovement();
        }

        private void StackMovement()
        {
            PositionHistory.Insert(0, parent.position);
            var index = 0;
            foreach (var stackObj in StackParts)
            {
                var point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];
                stackObj.transform.position=Vector3.Lerp(stackObj.transform.position,point,0.5f);
                //stackObj.transform.position = point;
                index++;
            }
        }

        private void GrowStack()
        {
            GameObject body = Instantiate(stackObjPrefab, parent);
            StackParts.Add(body);
        }
    }
}