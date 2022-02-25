using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public abstract class FormationBase : MonoBehaviour
    {
        [SerializeField] protected float spread = 1f;
        public abstract IEnumerable<Vector3> Points();
    }
}
