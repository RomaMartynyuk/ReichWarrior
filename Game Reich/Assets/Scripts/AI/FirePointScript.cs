using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointScript : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = playerPos.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
