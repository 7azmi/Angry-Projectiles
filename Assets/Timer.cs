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
        text.color = Color.white;

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
        text.text = $"Time: {timer.ToString("0.0")}s\n" +
            $"Distance: {bird.transform.position.x.ToString("0.0")}m\n" +
            $"Height: {bird.transform.position.y.ToString("0.0")}m\n" +
            $"Velocity: {bird.ready.rb.velocity.ToString("0.0")}";

        
    }

    public void StopCounting()
    {

        this.enabled = false;

        text.text = $"Time: {timer.ToString("0.0")}s\n" +
            $"Distance: {bird.transform.position.x.ToString("0.0")}m";
            //Height: 0.0m\n" +
            //$"Velocity: {bird.ready.rb.velocity.ToString("0.0")}";

        text.color = Color.red;

        //TooltipScreenSpaceUI.HideTooltip_Static();
    }

}
