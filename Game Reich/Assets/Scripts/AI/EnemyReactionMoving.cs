using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReactionMoving : MonoBehaviour
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

    public Transform[] MoveSpots;
    private int randomSpot;
    //patrolling
    private bool knowPlayer;
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, MoveSpots.Length);
        knowPlayer = false;
    }

    void Update()
    {
        if (Vector2.Distance(playerPos.position, transform.position) < range)
        {
            var direction = playerPos.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            knowPlayer = true;
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
        if (knowPlayer)
        {
            if (Vector2.Distance(playerPos.position, transform.position) > range && knowPlayer)
            {
                var direction = playerPos.position - transform.position;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            }
        }

        //mousePos = player.transform.position;
    }
    void Shooting()
    {
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.position * bulletForce, ForceMode2D.Impulse);
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
    void Patrolling()
    {
        var direction = MoveSpots[randomSpot].position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = Vector2.MoveTowards(transform.position, MoveSpots[randomSpot].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, MoveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime < 0)
            {
                randomSpot = Random.Range(0, MoveSpots.Length);
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
        if (Vector2.Distance(playerPos.position, transform.position) >= range && !knowPlayer)
        {
            Patrolling();
        }
        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.x, lookDir.y) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }
}
