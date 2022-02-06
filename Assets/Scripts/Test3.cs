using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Test3 : MonoBehaviour
{

    public Vector2 point1;
    public Vector2 point2;
    public Vector2 point3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    void Calc(float angle)
    {
        //point3
        float radAngle = angle * Mathf.Deg2Rad;
        float mag = point3.magnitude;
        float x = point1.x * Mathf.Cos(radAngle) - point1.y * Mathf.Sin(radAngle);
        float y = point1.x * Mathf.Sin(radAngle) + point1.y * Mathf.Cos(radAngle);

        point3 = new Vector2(x, y);
        point3 = point3.normalized * mag;
    }
    //[Button]
    //void Calc2(float angle)
    //{
    //    //point3
    //    float radAngle = angle * Mathf.Deg2Rad;
    //    //print(Mathf.Sin(radAngle));
    //    float x = point1.x * Mathf.Sin(radAngle);
    //    float y = point1.y * Mathf.Cos(radAngle);

    //    point3 = new Vector2(x, y);
    //}

    private void OnDrawGizmos()
    {
        //for (int i = 0; i < length; i++)
        //{

        //}
        Gizmos.DrawLine(Vector2.zero, point1);
        Gizmos.DrawLine(Vector2.zero, point2);
        Gizmos.DrawLine(Vector2.zero, point3);
    }
}
