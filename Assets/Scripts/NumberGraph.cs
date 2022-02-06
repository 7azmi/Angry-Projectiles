using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class NumberGraph : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    
    [Button]
    void CreateHorizontalLine()
    {

        for (int i = 0; i <= 20000; i+=10)
        {
            var ob = Instantiate(textPrefab, transform);

            ob.transform.position += new Vector3(i, 0, 0);
            ob.GetComponent<TextMeshPro>().text = "|\n" + i.ToString() +"m";
            ob.SetActive(true);
        }


    }
}
