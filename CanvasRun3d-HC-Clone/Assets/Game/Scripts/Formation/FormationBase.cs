using System.Collections.Generic;
using Game.Scripts.Patterns;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public abstract class FormationBase : MonoBehaviour
    {
        //[SerializeField] protected float spread = 1f;
        protected float spread => SettingsManager.GameSettings.formationSpread;
        public abstract IEnumerable<Vector3> LeaderPoints();
    }
}
