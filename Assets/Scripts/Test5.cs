using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test5 : MonoBehaviour
{
    public float power = 1f;
    public Camera cam;
    float horizontal;
    float vertical;
    void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        vertical = Input.GetAxis("Vertical") * Time.fixedDeltaTime;

        Vector2 dir =new Vector2(horizontal, vertical).normalized * power;
        if (dir.magnitude > 0) LinesHandler.OnRepositionCamera?.Invoke();
        cam.transform.position += (Vector3)dir;
    }
}
