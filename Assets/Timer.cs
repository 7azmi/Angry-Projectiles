using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void Update()
    {
        //float distance = 
        timer += Time.deltaTime;
        //text.text = $"Time: {timer.ToString("0.0")}s\n" +
        //    $"Distance: {bird.transform.position.x.ToString("0.0")}m\n" +
        //    $"Height: {bird.transform.position.y.ToString("0.0")}m\n" +
        //    $"Velocity: {bird.ready.rb.velocity.ToString("0.0")}";
        text.text = $"المدة: {timer.ToString("0.0")}ث\n" +
           $"الإزاحة: {bird.transform.position.x.ToString("0.0")}م\n" +
           $"الإرتفاع: {bird.transform.position.y.ToString("0.0")}م\n" +
           $"س.ل.س: {bird.ready.rb.velocity.x.ToString("0.0")}م/ث\n" +
           $"س.ل.ص: {bird.ready.rb.velocity.y.ToString("0.0")}م/ث";


    }

    public void StopCounting()
    {

        this.enabled = false;

        text.text = $"المدة: {timer.ToString("0.0")}ث\n" +
           $"الإزاحة: {bird.transform.position.x.ToString("0.0")}م";
        //Height: 0.0m\n" +
        //$"Velocity: {bird.ready.rb.velocity.ToString("0.0")}";

        text.color = Color.red;

        //TooltipScreenSpaceUI.HideTooltip_Static();
    }

}
