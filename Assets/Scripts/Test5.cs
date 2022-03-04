using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test5 : MonoBehaviour
{
    public float power = 1f;
    public Camera cam;
    float horizontal;
    float vertical;

    public static Action OnResizeCamera;
    public static Action OnRepositionCamera;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime;

        Vector2 dir =new Vector2(horizontal, vertical).normalized * power;
        //if (dir.magnitude > 0) LinesHandler.OnRepositionCamera?.Invoke();
        if (dir.magnitude > 0) OnRepositionCamera?.Invoke();
        cam.transform.position += (Vector3)dir;


        if (Input.GetKey(KeyCode.Q)) cam.orthographicSize -= Time.fixedDeltaTime * 50;
        if(Input.GetKey(KeyCode.E)) cam.orthographicSize += Time.fixedDeltaTime * 50;
    }
}
