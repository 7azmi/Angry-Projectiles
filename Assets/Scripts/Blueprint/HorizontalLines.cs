using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Blueprint
{
    public class HorizontalLines : Lines
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

            poses[0].x = CamPos.x - CamRadiusX;
            poses[1].x = CamPos.x + CamRadiusX;

            line.SetPositions(poses);
        }

        int[] Scan() => Scan((int)(CamPos.y - CamRadiusY), (int)(CamPos.y + CamRadiusY));//shortcut


        protected override void Create()
        {
            foreach (var p in Scan())
            {
                IEnumerable<LineRenderer> query = elements.Where(line => line.GetPosition(0).y == p);//should be one only

                if (query.Count() == 0)
                {
                    elements.Add(CreateLine(new Vector3[]{
                        new Vector3(CamPos.x - CamRadiusX, p, 0),
                        new Vector3(CamPos.x + CamRadiusX, p, 0)
                    }));
                }
            }
        }

        protected override bool InBorder(LineRenderer line)
        {
            //float linePos = line.GetPosition(0).y; //or 1

            //float padding = 1;

            //return Within(linePos, new Vector2(-CamRadiusY + CamPos.y - padding, CamRadiusY + CamPos.y + padding));

            return Scan().Any(p => p == line.GetPosition(0).y);
        }
    }
}
