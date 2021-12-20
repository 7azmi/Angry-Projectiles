using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Bow : MonoBehaviour
{
    //    public GameObject TrajectoryPointPrefeb;
    //    public GameObject BallPrefb;

    //    private GameObject ball;
    //    private bool isPressed, isBallThrown;
    //    private float power = 25;
    //    private int numOfTrajectoryPoints = 30;
    //    private List<GameObject> trajectoryPoints;
    //    //---------------------------------------	
    //    void Start()
    //    {
    //        trajectoryPoints = new List<GameObject>();
    //        isPressed = isBallThrown = false;
    //        for (int i = 0; i < numOfTrajectoryPoints; i++)
    //        {
    //            GameObject dot = (GameObject)Instantiate(TrajectoryPointPrefeb);
    ////            dot.GetComponent<Renderer>().enabled = false;
    //            trajectoryPoints.Insert(i, dot);
    //        }
    //    }
    //    //---------------------------------------	
    //    void Update()
    //    {
    //        if (isBallThrown)
    //            return;
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            isPressed = true;
    //            if (!ball)
    //                createBall();
    //        }
    //        else if (Input.GetMouseButtonUp(0))
    //        {
    //            isPressed = false;
    //            if (!isBallThrown)
    //            {
    //                throwBall();
    //            }
    //        }
    //        if (isPressed)
    //        {
    //            Vector3 vel = GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    //            float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
    //            transform.eulerAngles = new Vector3(0, 0, angle);
    //            setTrajectoryPoints(transform.position, vel / ball.rigidbody.mass);
    //        }
    //    }
    //    //---------------------------------------	
    //    // When ball is thrown, it will create new ball
    //    //---------------------------------------	
    //    private void createBall()
    //    {
    //        ball = (GameObject)Instantiate(BallPrefb);
    //        Vector3 pos = transform.position;
    //        pos.z = 1;
    //        ball.transform.position = pos;
    //        ball.SetActive(false);
    //    }
    //    //---------------------------------------	
    //    private void throwBall()
    //    {
    //        ball.SetActive(true);
    //        ball.rigidbody.useGravity = true;
    //        ball.rigidbody.AddForce(GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)), ForceMode.Impulse);
    //        isBallThrown = true;
    //    }
    //---------------------------------------	
    //private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    //{
    //    return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y)) * power;//*ball.rigidbody.mass;
    //}
    ////---------------------------------------	
    // It displays projectile trajectory path
    //---------------------------------------	


    public Bird birdy;
    public GameObject pointPrefab;
    public GameObject pointsParent;
    GameObject[] pointsCollecter;
    public int points = 10;

    public Vector2 velocity;
    //public float Velocity { get { return Mathf.Sqrt((velocity.x * velocity.x) + (velocity.y * velocity.y)); }}
    public float avgVelocity;
    public float angle;
    public float gravity = 1f;

    [Space]
    public SoundEffect BowSound;

    private void Start()
    {
        pointsCollecter = new GameObject[10];

        CreatePoints();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.)
    }

    void CreatePoints()
    {

        for (int i = 0; i < 10; i++)
        {
            pointsCollecter[i] = Instantiate(pointPrefab, pointsParent.transform);
            pointsCollecter[i].SetActive(true);
        }
    }

    void ShowPoints() => pointsParent.SetActive(true);
    void HidePoints() => pointsParent.SetActive(false);

    void AdjustPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        avgVelocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        float fTime = 0;

        fTime += 0.15f;
        for (int i = 0; i < points; i++)
        {
            //float dx = avgVelocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            //float dy = avgVelocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
            //Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, pStartPosition.z);
            pointsCollecter[i].transform.position = PointPosition(i*.1f);
            //pointsCollecter[i].renderer.enabled = true;
            //pointsCollecter[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }

        string data = $"Velocity: {avgVelocity.ToString("0.0")}m/s\n" +
            $"Angle: {angle.ToString("0.0")}°\n" +
            $"Vx:{velocity.x.ToString("0.0")}m/s\n" +
            $"Vy:{velocity.y.ToString("0.0")}m/s";
        TooltipScreenSpaceUI.ShowTooltip_Static(data);
    }

    Vector2 PointPosition(float t)
    {
        return (Vector2)transform.position + (velocity * t) + .5f * Physics2D.gravity * (t * t);

    }

    private void OnMouseDown()
    {
        //Velocity 
        ShowPoints();
        BowSound.Play();

    }

    private void OnMouseDrag()
    {

        float zFromBowToCam = transform.position.z - Camera.main.transform.position.z;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zFromBowToCam; // select distance = 10 units from the camera


        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {

        }

        velocity = (transform.position - Camera.main.ScreenToWorldPoint(mousePos)) * BowPower.bowPower;
        //print(transform.position);
        //print(
        AdjustPoints(transform.position, velocity);//velocity

    }

    private void OnMouseUp()
    {
        HidePoints();
        TooltipScreenSpaceUI.HideTooltip_Static();
        birdy.ChangeState(birdy.flying);

    }
}
