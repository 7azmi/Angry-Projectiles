using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Ready : MonoBehaviour, IState
{
    public StateMachineMB SM { get => GetComponent<StateMachineMB>(); }
    public Sprite ReadySprite;

    public Bow bow;
    internal Rigidbody2D rb;
    public SoundEffect Ready;

    public GameObject replyButton;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Enter()
    {
        replyButton.gameObject.SetActive(false);


        FindObjectOfType<Timer>().gameObject.SetActive(false);  



        GetComponent<SpriteRenderer>().sprite = ReadySprite;

        Ready.Play();
        rb.velocity = Vector2.zero;
        rb.SetRotation(0);
        //rb.simulated = true;
        rb.SetRotation(new Quaternion(0, 0, 0, 0));
        rb.gravityScale = 0;
        transform.position = bow.transform.position;
    }

    public void Exit()
    {
        //print(FindObjectOfType<Bow>().velocity);
        rb.AddForce(FindObjectOfType<Bow>().velocity, ForceMode2D.Impulse);
        rb.gravityScale = FindObjectOfType<Bow>().gravity;

        replyButton.gameObject.SetActive(true);
        
    }

    public void FixedTick()
    {
    }

    public void Tick()
    {
        
    }
}
