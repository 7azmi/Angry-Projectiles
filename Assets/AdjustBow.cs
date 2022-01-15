using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdjustBow : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI textHolder;



    public void OnValueChanged()
    {

        //float gravity;
        if (float.TryParse(inputField.text, out float newPos))
        {
            if (newPos > 9999 || newPos < 0)
            {
                TooltipScreenSpaceUI.ShowTooltip_Static("0~9999 فقط!");
                LeanTween.delayedCall(1f, () => TooltipScreenSpaceUI.HideTooltip_Static());
            }


            else
            {
                //newPos = Mathf.Clamp(newPos,0,2000);
                textHolder.text = "الارتفاع: " + newPos.ToString() + " متر";

                FindObjectOfType<Bow>().transform.position = new Vector3(0, newPos, 0);

                Bird_Ready ready = FindObjectOfType<Bird_Ready>();

                ready.Ready.Play();
                ready.rb.velocity = Vector2.zero;
                ready.rb.SetRotation(0);
                ready.rb.SetRotation(new Quaternion(0, 0, 0, 0));
                ready.rb.gravityScale = 0;
                ready.transform.position = FindObjectOfType<Bow>().transform.position;
            }



            
        }

    }
}
