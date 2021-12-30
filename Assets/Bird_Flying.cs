using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Flying : MonoBehaviour, IState
{
    public StateMachineMB SM {get;set;}
    Bird_Ready ready;
    public GameObject featherPrefab;

    public Sprite FlyingSprite;
    public Sprite HitSprite;

    public SoundEffect Flying;
    public SoundEffect Hit;

    public Timer timer;

    private void Awake()
    {
        ready = GetComponent<Bird_Ready>();
    }

    public void Enter()
    {
        Flying.Play();
        GetComponent<SpriteRenderer>().sprite = FlyingSprite;

        timer.StartCounting();
    }

    public void Exit()
    {
        for (int i = 0; i < Random.Range(2, 8); i++)
        {
            var f = Instantiate(featherPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            f.transform.localScale = new Vector2(Random.Range(.5f, 1), Random.Range(.5f, 1));
            f.SetActive(true);

            timer.StopCounting();
        }

        Hit.Play();
        GetComponent<SpriteRenderer>().sprite = HitSprite;
    }

    public void FixedTick()
    {
        Vector2 v = ready.rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Tick()
    {

        //transform.rotation = new Quaternion(0f,0f,angle,0); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GetComponent<StateMachineMB>().ChangeState(GetComponent<Bird>().hit);
            

        }
    }
}
