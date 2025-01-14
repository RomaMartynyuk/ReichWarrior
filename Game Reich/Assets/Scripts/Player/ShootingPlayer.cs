using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingPlayer : MonoBehaviour
{
    [Header("Bullet")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip FireSound;
    public AudioClip ReloadSound;

    [Header("Ammo")]
    public int maxAmmo = 30;
    private int currentAmmo;
    public int maxUsedAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float bulletForce = 20f;
    public string weaponName;
    public Sprite weaponPic;
    private bool reloadTimers;

    private GameObject weaponInHand;
    private GameObject weaponEternal;

    [Header("Showing")]
    public Text ammoDisplay;
    public Text maxAmmoDisplay;
    public Text weaponNameDisplay;
    public Image weaponPicDisplay;
    private void Start()
    {
        currentAmmo = maxUsedAmmo;
        reloadTimers = true;
    }
    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();
        maxAmmoDisplay.text = maxAmmo.ToString();
        weaponNameDisplay.text = weaponName.ToString();
        weaponPicDisplay.sprite = weaponPic;

        if (Input.GetKeyDown(KeyCode.R) && reloadTimers)
        {
            StartCoroutine(Reload());
            return;
        }
        if (isReloading) return;
        if(currentAmmo <= 0)
        {
            if (maxAmmo > 0)
            {
                StartCoroutine(Reload());
                return;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            weaponInHand.SetActive(false);
            weaponEternal.SetActive(true);
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        GetComponent<AudioSource>().PlayOneShot(FireSound);
        currentAmmo--;
    }
    IEnumerator Reload()
    {
        isReloading = true;
        reloadTimers = false;
        GetComponent<AudioSource>().PlayOneShot(ReloadSound);

        yield return new WaitForSeconds(reloadTime);

        if (maxUsedAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
            maxAmmo = 0;
        }
        if (maxUsedAmmo <= maxAmmo)
        {
            maxAmmo = maxAmmo - maxUsedAmmo;
            currentAmmo = maxUsedAmmo;
        }
        isReloading = false;
        reloadTimers = true;
    }
}
