using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReaction : MonoBehaviour
{
    [SerializeField] protected Transform playerPos;
    public float range;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;

    protected float timeBtwShots;
    public float startTimeBtwShots;

    [SerializeField] private float speed; 

    //Reaction
    private bool knowPlayer;
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
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
            if(Vector2.Distance(playerPos.position, transform.position) > range)
            {
                var direction = playerPos.position - transform.position;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
                transform.rotation = Quaternion.Euler(0, 0, angle);
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            }
        }
    }
    protected void Shooting()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
