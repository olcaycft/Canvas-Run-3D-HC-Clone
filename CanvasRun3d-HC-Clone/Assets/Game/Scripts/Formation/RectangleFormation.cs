using System;
using System.Collections.Generic;
using Game.Scripts.Managers;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public class RectangleFormation : FormationBase
    {
        [SerializeField] private int width = 5;
        //[SerializeField] private int length = 5;

        private void OnEnable()
        {
            StackManager.WidthChangedObserver += ChangeWidth;
        }

        private void OnDestroy()
        {
            StackManager.WidthChangedObserver -= ChangeWidth;
        }

        public override IEnumerable<Vector3> LeaderPoints()
        {
            var startOffSet = new Vector3(width * 0.5f, -0.5f, 0f);
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < 1; z++) //this is for ones becasue of this part contains our stack leaders.
                {
                    var pos = new Vector3(x, 0, -z); //its -z thats bcs of units will come back
                    pos -= startOffSet; // thats -= because of x dimention
                    pos += new Vector3(0.5f, 0, -0.5f);
                    pos *= base.spread;
                    yield return pos;
                }
            }
        }

        private void ChangeWidth(int width)
        {
            this.width = width;
        }
    }
}