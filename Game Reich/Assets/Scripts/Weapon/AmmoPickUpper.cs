using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUpper : MonoBehaviour
{
    [SerializeField] GameObject opened;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Work");
            ShootingPlayer shootingPlayer = collision.GetComponent<ShootingPlayer>();
            shootingPlayer.PickUpAdder();
            Destroy(gameObject);
            opened.SetActive(true);
        }
    }
}
