using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int health = 100;
    //public float speed;
    public GameObject deathEffect;
    public Transform player;
    private Vector3 startingPosition;


    private void Start()
    {
        startingPosition = transform.position;
    }

    private void Update()
    {
        //transform.Translate(transform.position, Player, speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
