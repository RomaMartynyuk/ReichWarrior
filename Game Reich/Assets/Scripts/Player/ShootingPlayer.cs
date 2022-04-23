using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootingPlayer : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip FireSound;
    public AudioClip ReloadSound;

    public int maxAmmo = 30;
    private int currentAmmo;
    public int maxUsedAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public float bulletForce = 20f;
    public string weaponName;
    public Sprite weaponPic;

    public GameObject weaponInHand;
    public GameObject weaponEternal;

    //pickup
    [SerializeField] GameObject pistol;
    [SerializeField] GameObject rifle;
    [SerializeField] GameObject automatic;
    //pickup

    public Text ammoDisplay;
    public Text maxAmmoDisplay;
    public Text weaponNameDisplay;
    public Image weaponPicDisplay;
    private void Start()
    {
        currentAmmo = maxUsedAmmo;
    }
    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString();
        maxAmmoDisplay.text = maxAmmo.ToString();
        weaponNameDisplay.text = weaponName.ToString();
        weaponPicDisplay.sprite = weaponPic;

        if (Input.GetKeyDown(KeyCode.R))
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
    }
    public void PickUpAdder()
    {
        if (gameObject.CompareTag("Rifle"))
            maxAmmo += 5;
        if (gameObject.CompareTag("Pistol"))
            maxAmmo += 8;
        if (gameObject.CompareTag("Automatic"))
            maxAmmo += 32;
    }
}
