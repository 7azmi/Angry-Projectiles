using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class Bird : StateMachineMB
{
    //[SerializeField, FoldoutGroup("Sprites")] Sprite idleS, flyingS, hitS, deadS;

    internal Bird_Ready ready { get; set; }
    internal Bird_Flying flying { get; set; }
    internal Bird_Hit hit { get; set; }

    private void Start()
    {

        ready = GetComponent<Bird_Ready>();
        flying = GetComponent<Bird_Flying>();
        hit = GetComponent<Bird_Hit>();


        ChangeState(ready);
    }

    public void ChangeStateToReady()
    {
        ChangeState(ready);

    }
}

