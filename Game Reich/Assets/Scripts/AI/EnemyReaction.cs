using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReaction : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    public float range;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;

    private float timeBtwShots;
    public float startTimeBtwShots;
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
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
}
