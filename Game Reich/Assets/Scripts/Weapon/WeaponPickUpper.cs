using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUpper : MonoBehaviour
{
    public GameObject weapon;
    public GameObject curWeapon;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            weapon.SetActive(true);
            curWeapon.SetActive(false);
            Destroyer();
        }
    }
    private void Destroyer()
    {
        Destroy(gameObject);
    }
}
