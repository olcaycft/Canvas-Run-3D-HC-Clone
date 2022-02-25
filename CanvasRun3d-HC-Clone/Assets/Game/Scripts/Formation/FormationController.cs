using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public class FormationController : MonoBehaviour
    {
        private FormationBase _formation;
        private FormationBase formation => _formation ??= GetComponent<FormationBase>();

        [SerializeField] private GameObject unitPrefab;
        private List<GameObject> spawnedUnits = new List<GameObject>();
        private List<Vector3> points = new List<Vector3>();


        private void Update()
        {
            SetFormation();
        }

        private void SetFormation()
        {
            points = formation.Points().ToList();
            if (points.Count > spawnedUnits.Count)
            {
                var newPoints = points.Skip(spawnedUnits.Count);
                Spawn(newPoints);
            }
            else if (points.Count < spawnedUnits.Count)
            {
                Kill(spawnedUnits.Count - points.Count);
            }

            for (int i = 0; i < spawnedUnits.Count; i++)
            {
                spawnedUnits[i].transform.position = transform.position + points[i];
            }
        }
        
        private void Spawn(IEnumerable<Vector3> points) //its will be replace with obj pool later
        {
            foreach (var pos in points)
            {
                var unit = Instantiate(unitPrefab, transform.position + pos, Quaternion.identity, transform);
                spawnedUnits.Add(unit);
            }
        }

        private void Kill(int num) //its will be replace with obj pool later
        {
            for (int i = 0; i < num; i++)
            {
                var unit = spawnedUnits.Last();
                spawnedUnits.Remove(unit);
                Destroy(unit.gameObject);
            }
        }
    }
}