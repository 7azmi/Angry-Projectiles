using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;

public class test6 : MonoBehaviour
{
    public Transform point;


    [ContextMenu("boi")]
    void Test()
    {
        print((int)-1.5f); //-1
        print((int)-0.5f); //0
        print((int)0.5f);  //0
        print((int)1.5f);  //1
    }
}
