using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GravitryChanger : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI textHolder;



    private void Awake()
    {
        textHolder.text = "الجاذبية: " + Physics2D.gravity.y.ToString() + " نيوتن";
        
    }
    public void OnValueChanged(string value)
    {
        
        //float gravity;
        if(float.TryParse(inputField.text, out float gravity))
        {
            Physics2D.gravity = new Vector2(0, gravity);
            //print("it works");
        }
        //Physics2D.gravity = new Vector2(0, 
        textHolder.text = "الجاذبية: " + Physics2D.gravity.y.ToString() + " نيوتن";

    }
}
