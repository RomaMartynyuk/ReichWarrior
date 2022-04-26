using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMoving : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float timeDeath = 30;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        timeDeath -= Time.deltaTime;
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if(timeDeath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
