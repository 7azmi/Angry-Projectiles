using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{

    private void OnEnable()
    {
        float camZ = Camera.main.transform.position.z;
        Vector3 printme = Camera.main.ScreenToWorldPoint(transform.position - new Vector3(0,0,camZ));
        print(printme);
    }
}
