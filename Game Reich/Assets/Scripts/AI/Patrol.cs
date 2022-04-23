using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    //public Transform[] moveSpots;
    public Transform moveSpot;//del
    //private int randomSpot;
    //del
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    //del

    public void Start()
    {
        waitTime = startWaitTime;
        //randomSpot = Random.Range(0, moveSpots.Length);
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));//del
    }
    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot/*s[randomSpot]*/.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot/*s[randomSpot]*/.position) < 0.2f)
        {
            if(waitTime < 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));//del
                //randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
