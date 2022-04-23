using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReactionRandomMoving : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    public float range;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;

    private float timeBtwShots;
    public float startTimeBtwShots;

    //patrolling
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    //patrolling
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        if (Vector2.Distance(playerPos.position, transform.position) < range)
        {
            var direction = playerPos.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            if(timeBtwShots <= 0)
            {
                Shooting();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots-=Time.deltaTime;
            }
        }
    }
    void Shooting()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
    void Patrolling()
    {
        var direction = moveSpot.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if(waitTime < 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= startWaitTime;
            }
        }
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(playerPos.position, transform.position) >= range)
        {
            Patrolling();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }
}
