using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public float range;
    public Transform target;
    bool detected = false;
    Vector2 direction;
    public GameObject gun;
    void Start()
    {
        
    }

    void Update()
    {
        Vector2 targetPos = target.position;

        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);

        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(detected == false)
                {
                    detected = true;
                    Debug.Log("Detected");
                }
            }
            else
            {
                if(detected == true)
                {
                    detected = false;
                    Debug.Log("Not Detected");
                }
            }
        }
        if (detected)
        {
            gun.transform.up = direction;
        }
    }
}
