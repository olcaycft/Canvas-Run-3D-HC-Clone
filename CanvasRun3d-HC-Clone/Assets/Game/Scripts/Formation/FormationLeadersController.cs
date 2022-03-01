using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Patterns;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public class FormationLeadersController : MonoBehaviour
    {
        private FormationBase _formation;
        private FormationBase formation => _formation ??= GetComponent<FormationBase>();

        [SerializeField] private GameObject unitPrefab;
        [SerializeField] private List<GameObject> spawnedUnits = new List<GameObject>();
        [SerializeField] private List<Vector3> points = new List<Vector3>();

        private void Update()
        {
            SetFormation();
        }

        private void SetFormation()
        {
            points = formation.LeaderPoints().ToList();
            if (points.Count > spawnedUnits.Count)
            {
                var newPoints = points.Skip(spawnedUnits.Count);
                Spawn(newPoints);
            }
            else if (points.Count < spawnedUnits.Count)
            {
                Kill(spawnedUnits.Count - points.Count);
            }

            for (var i = 0; i < spawnedUnits.Count; i++)
            {
                spawnedUnits[i].transform.position = transform.position + points[i];
            }
        }

        private void Spawn(IEnumerable<Vector3> points) //its will be replace with obj pool later
        {
            foreach (var pos in points)
            {
                var unit = Instantiate(unitPrefab, transform.position + pos, Quaternion.identity, transform);
                //var unit = ObjectPooler.Instance.SpawnFromPool("Leader", transform.position + pos, Quaternion.identity);
                unit.transform.SetParent(gameObject.transform);
                
                IOnUnitSpawn spawnedUnit = unit.GetComponent<IOnUnitSpawn>();
                spawnedUnit.OnUnitSpawn();
                spawnedUnits.Add(unit);
            }
        }

        private void Kill(int num) //its will be replace with obj pool later
        {
            for (var i = 0; i < num; i++)
            {
                var unit = spawnedUnits.Last();
                spawnedUnits.Remove(unit);
                //Destroy(unit.gameObject);
                unit.transform.SetParent(null);
                unit.transform.position=Vector3.zero;
                unit.SetActive(false);
                
                
            }
        }
    }
}