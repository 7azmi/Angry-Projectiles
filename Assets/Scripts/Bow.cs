using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using System;
using DTT.Utils;

public class Bow : MonoBehaviour
{
    public Bird birdy;
    public GameObject pointPrefab;
    public GameObject pointsParent;
    GameObject[] pointsCollecter;
    public int points = 10;

    public Vector2 velocity; //the bad boy
    //public float Velocity { get { return Mathf.Sqrt((velocity.x * velocity.x) + (velocity.y * velocity.y)); }}
    public float avgVelocity;
    public float angle;
    public float gravity = 1f;

    [Space]
    public SoundEffect BowSound;

    private void Start()
    {
        pointsCollecter = new GameObject[10];
        //string s;
        
        CreatePoints();
    }

    // Update is called once per frame
    void Update()
    {

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

        //string data = $"السرعة: {avgVelocity.ToString("0.0")}م/ث\n" +
        //    $"الزاوية: {angle.ToString("0.0")}°\n" +
        //    $"س.ل.س: {velocity.x.ToString("0.0")}م/ث\n" +
        //    $"س.ل.ص: {velocity.y.ToString("0.0")}م/ث";
        //TooltipScreenSpaceUI.ShowTooltip_Static(data);
    }

    Vector2 PointPosition(float t)
    {
        return (Vector2)transform.position + (velocity * t) + .5f * Physics2D.gravity * (t * t);

    }

    public static Action BowDown { get; set; }
    private void OnMouseDown()
    {
        BowDown?.Invoke();
        //Velocity 
        ShowPoints();
        BowSound.Play();

    }

    bool ctrlPressed;
    bool sheftPressed;

    float lockedAngle;
    Vector2 lockedDir;
    private void OnMouseDrag()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        //float zFromBowToCam = transform.position.z - Camera.main.transform.position.z;
        //mousePos.z = zFromBowToCam; // select distance = 10 units from the camera

        Vector2 generatedVelocity = -(transform.position - Camera.main.ScreenToWorldPoint(mousePos)) * BowPower.bowPower;
        

        //sheft => to adjust to famous angles 15+ (just like in photoshop)
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) sheftPressed = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) sheftPressed = false;
        //control => to lock angle
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        { 
            ctrlPressed = true;
            lockedDir = generatedVelocity;
            lockedAngle = (Mathf.Atan2(generatedVelocity.y, generatedVelocity.x));
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl)) ctrlPressed = false;


        if(ctrlPressed)
        {
            //adjust generated velocity to locked angle
            //float AngleDisplacement = lockedAngle - ((Mathf.Rad2Deg * Mathf.Atan2(generatedVelocity.y, generatedVelocity.x)));
            float mag = generatedVelocity.magnitude;
            float x = lockedDir.x * Mathf.Cos(lockedAngle) - lockedDir.y * Mathf.Sin(lockedAngle);
            float y = lockedDir.x * Mathf.Sin(lockedAngle) + lockedDir.y * Mathf.Cos(lockedAngle);

            generatedVelocity = new Vector2(x, y);
            generatedVelocity = lockedDir.normalized * mag;
            velocity = -generatedVelocity;

            //velocity =  Quaternion.Euler(0, AngleDisplacement, 0) * generatedVelocity;
            //float newX = generatedVelocity.x * Mathf.Cos(AngleDisplacement) - generatedVelocity.y * Mathf.Sin(AngleDisplacement);
            //float newY = generatedVelocity.x * Mathf.Sin(AngleDisplacement) + generatedVelocity.y * Mathf.Cos(AngleDisplacement);
            //velocity = new Vector2(newX, newY);
            //print(lockedAngle);
            //velocity = generatedVelocity * Mathf.Cos(AngleDisplacement * Mathf.Deg2Rad);
            //Debug.Log(Mathf.Cos(AngleDisplacement * Mathf.Deg2Rad));
            //Vector2 changeAtAngle = generatedVelocity = -(lockedVector * avgRatio);

        }else if (sheftPressed)
        {
            float fixedAngle = NearestAngle(Mathf.Atan2(generatedVelocity.y, generatedVelocity.x) * Mathf.Rad2Deg);
            //print(fixedAngle);
            float mag = generatedVelocity.magnitude;
            Vector2 ceen = new Vector2(1, 0);
            float x = ceen.x * Mathf.Cos(fixedAngle) - ceen.y * Mathf.Sin(fixedAngle);
            float y = ceen.x * Mathf.Sin(fixedAngle) + ceen.y * Mathf.Cos(fixedAngle);

            generatedVelocity = new Vector2(x, y);
            generatedVelocity = generatedVelocity.normalized * mag;
            velocity = -generatedVelocity;
        }
        else
        {
            velocity = -generatedVelocity;
        }

        AdjustPoints(transform.position, velocity);

    }

    float[] famousAngles = new float[] {-180, -165, -150, -135, -120 ,-105, -90, -75, -60, -45, -30, -15,
        0, 15, 30, 45, 60, 75, 90, 105, 120, 135, 150, 165, 180 };

    float NearestAngle(float angle)
    {
        //float nearestAngle = famousAngles.OrderBy(v => Math.Abs((float)v - (angle))).First();
        //print(angle);
        return famousAngles.OrderBy(v => Math.Abs((float)v - angle)).First() * Mathf.Deg2Rad;
    }

    private void OnMouseUp()
    {
        sheftPressed = false;
        ctrlPressed = false;
        HidePoints();
        TooltipScreenSpaceUI.HideTooltip_Static();
        birdy.ChangeState(birdy.flying);

    }

    
}
