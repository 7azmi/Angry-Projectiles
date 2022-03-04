using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Blueprint
{
    public class HorizontalRuler : Ruler
    {



        protected override void Adjust(int i)
        {
            Vector2 newPos = WrldToScrn(new Vector2(int.Parse(elements[i].text), 0));

            newPos.y = ScrnY;//position

            elements[i].transform.position = newPos;
        }

        int[] Scan() => Scan((int)ScrnToWrld(new Vector2(0, 0)).x,(int)ScrnToWrld(new Vector2(ScrnX, 0)).x);

        protected override void Create()
        {

            foreach (var p in Scan())
            {
                IEnumerable<Text> query = elements.Where(value => int.Parse(value.text) == p);//should be one only

                Vector2 newPos = WrldToScrn(new Vector2(p, 0));
                newPos.y = ScrnY;//up there

                if (query.Count() == 0) elements.Add(CreateText(newPos, p));
            }
        }

        protected override bool InBorder(Text txt) => Scan().Any(p => p == int.Parse(txt.text));
    }
}
