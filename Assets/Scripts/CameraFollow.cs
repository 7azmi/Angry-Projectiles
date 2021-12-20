using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float moveSpeed=5f;
    [SerializeField] float zoomSpeed = 5;
    [SerializeField] Transform target;

    //public int cameraZoom;
    Vector2 movement;


    public float CameraSize { get { return Camera.main.orthographicSize; } }

    Vector3 offset;

    private void Awake()
    {

        movement = Vector2.zero;
    }



    private void Update()
    {
        Inputs();

        float yLength = (15 - CameraSize);
        float xLength = yLength * ((float)((float)Screen.width / (float)Screen.height));

        //movement = movement.normalized;

        float yBorder = Mathf.Clamp(transform.position.y + movement.y, -yLength, yLength);
        float xBorder = Mathf.Clamp(transform.position.x + movement.x, -xLength, xLength);

        Vector3 cameraBounds = new Vector3(xBorder, yBorder, -10);
        transform.position = cameraBounds;
    }

    private void Inputs()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1 * Time.deltaTime * moveSpeed;
        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1 * Time.deltaTime * moveSpeed;
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1 * Time.deltaTime * moveSpeed;
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1 * Time.deltaTime * moveSpeed;
        }


        if (Input.mouseScrollDelta.y != 0)
        {
            float zoomBound = Mathf.Clamp(Input.mouseScrollDelta.y * -1 * zoomSpeed + CameraSize, 5, 10);

            Camera.main.orthographicSize = zoomBound;
        }
    }
}
