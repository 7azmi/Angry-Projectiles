using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    float timer;

    Bird bird;

    private void Awake()
    {
        //gameObject.SetActive(false);
        bird = FindObjectOfType<Bird>();
    }

    public void StartCounting()
    {

        timer = 0;
        text.gameObject.SetActive
            (true);
        this.enabled = true;
    }

    private void Update()
    {
        //float distance = 
        timer += Time.deltaTime;
        text.text = $"{timer.ToString("0.0")}s\n" +
            $"{bird.transform.position.x.ToString("0.0")}m";
    }

    public void StopCounting()
    {
        this.enabled = false;
        text.color = Color.red;
    }

}
