using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Blueprint
{
    public class VerticalRuler : Ruler
    {



        protected override void Adjust(int i)
        {
            Vector2 newPos = WrldToScrn(new Vector2(0, int.Parse(elements[i].text)));
            newPos.x = 0;//left
            elements[i].transform.position = newPos;
        }

        int[] Scan() => Scan((int)ScrnToWrld(new Vector3(0, 0, 0)).y, (int)ScrnToWrld(new Vector3(0, ScrnY, 0)).y);

        protected override void Create()
        {
            foreach (var p in Scan())
            {

                IEnumerable<Text> query = elements.Where(value => int.Parse(value.text) == p);//should be one only
                Vector2 newPos = WrldToScrn(new Vector2(0, p));
                newPos.x = 0;//left
                if (query.Count() == 0) elements.Add(CreateText(newPos, p));
            }
        }

        protected override bool InBorder(Text txt) => Scan().Any(p => p == int.Parse(txt.text));

    }
}
