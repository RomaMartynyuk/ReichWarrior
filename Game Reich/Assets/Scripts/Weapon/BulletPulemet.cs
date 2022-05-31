using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPulemet : MonoBehaviour
{
   //public GameObject hitEffect;
    public float speed;
    public float time;
    public float distance;
    public int damage = 10;
    public LayerMask whatIsSolid;
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, 5f);
    //    Destroy(gameObject);
    //}
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerMovement>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Environment"))
            {
                Destroy(gameObject);
            }
        }
    }
}
