using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPower : MonoBehaviour
{
    public static float bowPower = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnValueChanged()
    {
        float value = Mathf.Clamp(GetComponent<UnityEngine.UI.Scrollbar>().value, 0.1f, 1);
        bowPower = 20 * value;
    }
}
