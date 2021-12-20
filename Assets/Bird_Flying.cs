using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Flying : MonoBehaviour, IState
{
    public StateMachineMB SM => throw new System.NotImplementedException();
    public GameObject featherPrefab;

    public Sprite FlyingSprite;
    public Sprite HitSprite;

    public SoundEffect Flying;
    public SoundEffect Hit;

    public Timer timer;
    public void Enter()
    {
        Flying.Play();
        GetComponent<SpriteRenderer>().sprite = FlyingSprite;

        timer.StartCounting();
    }

    public void Exit()
    {
    }

    public void FixedTick()
    {
    }

    public void Tick()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //GetComponent<Rigidbody2D>().simulated = false;
            for (int i = 0; i < Random.Range(2,8); i++)
            {
                var f = Instantiate(featherPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                f.transform.localScale = new Vector2(Random.Range(.5f, 1), Random.Range(.5f, 1));
                f.SetActive(true);

                timer.StopCounting();
            }

            Hit.Play();
            GetComponent<SpriteRenderer>().sprite = HitSprite;

        }
    }
}
