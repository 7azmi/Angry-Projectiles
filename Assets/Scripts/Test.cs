using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Test : MonoBehaviour
{

    public GameObject groundPrefab;


    [Button]
    void Create()
    {
        for (int i = 1; i < 1000; i++)
        {
            var g = Instantiate(groundPrefab, transform);
            g.transform.position -= new Vector3(45*i, 0,0);
        }
        for (int i = 1; i < 1000; i++)
        {
            var g = Instantiate(groundPrefab, transform);
            g.transform.position -= new Vector3(-45 * i, 0,0);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
