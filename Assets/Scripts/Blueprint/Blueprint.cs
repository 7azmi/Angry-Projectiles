using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Blueprint
{
    public abstract class Blueprint<T> : MonoBehaviour
    {
        [SerializeField] protected GameObject prefab;

        [SerializeField] protected List<T> elements;//lines & texts
        //protected static int DisplayElementRate = 5;

        protected static int DisplayElementRate => AdjustDisplayRate();

        protected Vector3 CamPos => Camera.main.transform.position;
        protected float CamSize => Camera.main.orthographicSize;
        protected float ScrnX => Screen.width;
        protected float ScrnY => Screen.height;

        private void Awake() => elements = new List<T>();


        protected int[] Scan(int point1, int point2)//The queen
        {
            IEnumerable<int> points = Enumerable.Range(point1, point2 - point1 + 1).
                Where(s => s % DisplayElementRate == 0);

            return points.ToArray();
        }

        static int AdjustDisplayRate()//for now
        {
            //1 => 1-9
            //5 => 10-49 
            //10 => 50-99

            float points = Camera.main.orthographicSize;

            if (Within(points , new Vector2(1, 10))) return 1;
            if (Within(points, new Vector2(10, 50))) return 5;
            if (Within(points, new Vector2(50, 100))) return 10;
            if (Within(points, new Vector2(100, 500))) return 50;
            if (Within(points, new Vector2(500, 1000))) return 100;
            //if (Within(points, new Vector2(1, 9))) return 1;
            return 99999; //lol
        }

        private void Update()//works fine for now
        {
            Refresh();
        }

        /// <summary>
        /// Logic:
        /// adjust elements' positions and count in List, then eliminate what is out bounds
        /// next, scan and create whatever is needed.
        /// simple :)
        /// </summary>
        void Refresh()
        {
            AdjustAndClean();

            Create();

        
        }

        protected void AdjustAndClean()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                Adjust(i);
                Clean(i);
            }
        }

        protected abstract void Adjust(int i);

        protected void Clean(int i)
        {
            if (!InBorder(elements[i]))
            {
                DestroyMe(elements[i]);
                elements.RemoveAt(i);
            }
        }

        protected abstract void Create();

        protected abstract void DestroyMe(T victim);

        protected abstract bool InBorder(T element);

        protected static bool Within(float value, Vector2 range) => value >= range.x && value <= range.y;//x min, y max

        public static Vector3 WrldToScrn(Vector3 pos) => Camera.main.WorldToScreenPoint(pos);
        public static Vector3 ScrnToWrld(Vector3 pos) => Camera.main.ScreenToWorldPoint(pos);
    }
}
