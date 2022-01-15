using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test4 : MonoBehaviour
{
    float[] array = new float[] {-180, -165, -150, -135, -120 ,-105, -90, -75, -60, -45, -30, -15,
        0, 15, 30, 45, 60, 75, 90, 105, 120, 135, 150, 165, 180 };

    public float targetNumber = 20;
    // Start is called before the first frame update
    void OnEnable()
    {
        var closest = array.OrderBy(v => Math.Abs((long)v - targetNumber)).First();
        print(closest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
