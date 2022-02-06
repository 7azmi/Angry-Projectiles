using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        { 
            TooltipScreenSpaceUI.HideTooltip_Static();
            FindObjectOfType<Bird>().ChangeStateToReady(); 
        }
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
