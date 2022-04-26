using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    [SerializeField] GameObject truck;
    private float timeBtwSpawn;
    [SerializeField] float startTimeBtwSpawn;
    void Start()
    {
        timeBtwSpawn = startTimeBtwSpawn;
    }
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(truck, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else 
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
