using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAim : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private GameObject bulletTankPreFab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce;
    private bool shootReady;
    private void Start()
    {
        shootReady = true;
    }
    private void Update()
    {
        Vector3 aim = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + offset) ;
        if (Input.GetMouseButtonDown(0) && shootReady)
        {
            StartCoroutine(Wait());
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletTankPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        shootReady = false;
    }
    IEnumerator Wait()
    {
        Shoot();

        yield return new WaitForSeconds(7);

        shootReady = true;
    }
}
