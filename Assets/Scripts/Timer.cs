using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DTT.Utils.Extensions;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    float timer;

    Bird bird;

    Vector2 BirdVelocity { get => bird.ready.rb.velocity; }

    private void Awake()
    {
        //gameObject.SetActive(false);
        bird = FindObjectOfType<Bird>();
    }

    public void StartCounting()
    {
        text.color = Color.black;

        timer = 0;
        text.gameObject.SetActive
            (true);
        this.enabled = true;


        //System.Func<string> getTooltipTextFunc = () => {
        //    return $"Vx: {BirdVelocity.x.ToString("0.0")}\n" +
        //    $"Vy: {BirdVelocity.y.ToString("0.0")}";
        //};

        //TooltipScreenSpaceUI.ShowTooltip_Static(getTooltipTextFunc);
    }

    float? maxHeight;
    string maxHeight_String = "";
    private void OnEnable() { maxHeight = null; maxHeight_String = ""; }
    private void Update()
    {
        //float distance = 
        timer += Time.deltaTime;
        //text.text = $"Time: {timer.ToString("0.0")}s\n" +
        //    $"Distance: {bird.transform.position.x.ToString("0.0")}m\n" +
        //    $"Height: {bird.transform.position.y.ToString("0.0")}m\n" +
        //    $"Velocity: {bird.ready.rb.velocity.ToString("0.0")}";
        //string maxHeight_String = "";
        if(bird.ready.rb.velocity.y <0 && maxHeight == null)
        {
            maxHeight = bird.transform.position.y;
            float maxY = (float)maxHeight; //stupid C#, don't delete or ToString(); will nag
            maxHeight_String = $"Max: {maxY.ToString("0.0")}m".Color(Color.red);
            //maxHeight_String= maxHeight_String.Color
        }

        text.text = $"Time: {timer.ToString("0.0")}s\n" +
           $"Displacement: {bird.transform.position.x.ToString("0.0")}m\n" +
           $"Height: {bird.transform.position.y.ToString("0.0")}m    {maxHeight_String}\n" + 
            $"Speed:{bird.ready.rb.velocity.magnitude.ToString("0.0")}m/s\n" +
           $"Vx: {bird.ready.rb.velocity.x.ToString("0.0")}m/s\n" +
           $"Vy: {bird.ready.rb.velocity.y.ToString("0.0")}m/s";


    }

    public void StopCounting()
    {

        this.enabled = false;

        text.text = $"Period: {timer.ToString("0.0")}s\n" +
           $"Displacement: {bird.transform.position.x.ToString("0.0")}m";
        //Height: 0.0m\n" +
        //$"Velocity: {bird.ready.rb.velocity.ToString("0.0")}";

        text.color = Color.red;

        //TooltipScreenSpaceUI.HideTooltip_Static();
    }

}
