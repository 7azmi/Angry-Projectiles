using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Blueprint
{
    public class VerticalLines : Lines
    {

        protected override void Adjust(int i)
        {
            AdjustLinePosition(elements[i]);
            AdjustLineThickness(elements[i]);
        }

        protected override void AdjustLinePosition(LineRenderer line)
        {
            Vector3[] poses = new Vector3[line.positionCount];
            line.GetPositions(poses);

            poses[0].y = CamPos.y - CamRadiusY;
            poses[1].y = CamPos.y + CamRadiusY;
        
            line.SetPositions(poses);
        }

        private int[] Scan() => Scan((int)(CamPos.x - CamRadiusX), (int)(CamPos.x + CamRadiusX));

        protected override void Create()
        {
            foreach (var p in Scan())
            {
                IEnumerable<LineRenderer> query = elements.Where(line => line.GetPosition(0).x ==p);//should be one only
            
                if (query.Count() == 0)
                {
                    elements.Add(CreateLine(new Vector3[]{
                        new Vector3(p,CamPos.y - CamRadiusY,0),
                        new Vector3(p,CamPos.y + CamRadiusY,0)
                    }));
                }
            }

            //AdjustLineThickness(elements .Last());
        }

        protected override bool InBorder(LineRenderer line)
        {
            //float linePos = line.GetPosition(0).x; //or 1

            //float padding = 1;

            //return Within(linePos, new Vector2(-CamRadiusX + CamPos.x - padding, CamRadiusX + CamPos.x + padding));

            return Scan().Any(p => p == line.GetPosition(0).x);
        }

 
    }
}
