using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Formation
{
    public class RectangleFormation : FormationBase
    {
        [SerializeField] private int width = 5;
        [SerializeField] private int length = 5;

        
        public override IEnumerable<Vector3> Points()
        {
            var startOffSet = new Vector3(width * 0.5f, -0.5f, 0f);
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var pos = new Vector3(x, 0, -z); //its -z thats bcs of units will come back
                    pos -= startOffSet; // thats -= because of x dimention
                    pos += new Vector3(0.5f, 0, -0.5f);
                    pos *= base.spread;
                    yield return pos;
                }
            }
        }
    }
}