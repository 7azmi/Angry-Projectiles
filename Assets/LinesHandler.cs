using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class LinesHandler : MonoBehaviour
{
    [SerializeField] protected GameObject lineRendererPrefab;

    protected List<LineRenderer> lines;

    public static Action OnResizeCamera;
    public static Action OnRepositionCamera;
    public static Action OnSuddenRepositionCamera; // you know what it is, worrrrd up.

    protected Vector3 CameraPos { get => Camera.main.transform.position; }
    protected float CameraSize { get { return Camera.main.orthographicSize; } }
    protected float camX;
    protected float camY;

    public virtual void Awake()
    {
        camX = Screen.width;
        camY = Screen.height;
    }

    [SerializeField] protected float LineThicknessMultiplier = 1f;
    [SerializeField] protected int thickerLineEach = 10;

    

    protected LineRenderer CreateLine(Vector3[] poses)
    {
        GameObject pref = Instantiate(lineRendererPrefab, transform);
        LineRenderer line = pref.GetComponent<LineRenderer>();
        line.SetPositions(poses);
        

        pref.SetActive(true);

        return line;
    }

}
