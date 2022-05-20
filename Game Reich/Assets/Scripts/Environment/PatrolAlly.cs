using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAlly : MonoBehaviour
{
    [SerializeField] private float speed;
    private float waitTime;
    [SerializeField] private float startWaitTime;

    [SerializeField] Transform[] MoveSpots;
    private int randomSpot;

    private void Start()
    {
        waitTime = startWaitTime;
    }
    void Update()
    {
        var direction = MoveSpots[randomSpot].position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.position = Vector2.MoveTowards(transform.position, MoveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, MoveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime < 0)
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
}
