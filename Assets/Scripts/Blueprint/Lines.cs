using UnityEngine;
using UnityEngine.Serialization;

namespace Blueprint
{
    public abstract class Lines : Blueprint<LineRenderer>
    {
        [SerializeField, Range(0.001f, 0.010f)] protected float lineThicknessMultiplier = 0.005f;

        protected float CamRadiusY => CamSize;
        protected float CamRadiusX => ScrnX / ScrnY * CamSize; 

        //protected virtual void Awake() => elements = new List<LineRenderer>();

        protected LineRenderer CreateLine(Vector3[] poses)
        {
            lineThicknessMultiplier = 1;
            GameObject obj = Instantiate(prefab, transform);
            LineRenderer line = obj.GetComponent<LineRenderer>();
            line.SetPositions(poses);

            //to prevent weird behavior
            AdjustLineThickness(line);

            obj.SetActive(true);

            return line;
        }
        protected abstract void AdjustLinePosition(LineRenderer line);

        protected override void DestroyMe(LineRenderer victim) => Destroy(victim.gameObject);

        protected void AdjustLineThickness(LineRenderer line)
        {
            float lineThickness = lineThicknessMultiplier * CamSize;
            line.widthMultiplier = lineThickness;
        }
    }
}
