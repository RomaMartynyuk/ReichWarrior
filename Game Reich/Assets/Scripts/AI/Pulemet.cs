using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulemet : EnemyReaction
{
    [SerializeField] private int ammo = 30;
    private float timerShot = 0.1f;
    private float rotZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerPos.position, transform.position) < range)
        {
            var direction = playerPos.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            if(angle > 65f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 65f);
                firePoint.gameObject.SetActive(false);
            }
            else if(angle < -65f)
            {
                transform.rotation = Quaternion.Euler(0, 0, -65f);
                firePoint.gameObject.SetActive(false);
            }
            else if (timeBtwShots <= 0 && ammo>0 && timerShot <0)
            {
                Shooting();
                ammo--;
                timerShot = 0.1f;
            }
            else if (ammo <= 0)
            {
                timeBtwShots = startTimeBtwShots;
                ammo = 30;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            if (timerShot > 0)
            {
                timerShot -= Time.deltaTime;
            }
        }
    }
}
