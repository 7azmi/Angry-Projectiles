using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPower : MonoBehaviour
{
    public static float bowPower = 15;
    // Start is called before the first frame update
    void Start()
    {
        //OnValueChanged();
        GetComponent<UnityEngine.UI.Scrollbar>().value = .2f; //Random.Range(0.f, 1f);
    }

    public void OnValueChanged()
    {
        float value = Mathf.Clamp(GetComponent<UnityEngine.UI.Scrollbar>().value, 0.05f, 1);

        bowPower = 50 * value;
    }
}
