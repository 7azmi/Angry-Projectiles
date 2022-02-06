using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DTT.Utils.Extensions;

public class Test4 : MonoBehaviour
{

    string data;
    public string angle;


    private void OnEnable()
    {
        //angle = angle.Color(Color.red);

        
        data = $"Angle: {angle.Color(Color.red)}";
        print(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
