using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public int maxWeapon = 3;
    private int ScrolInt;

    public string ammoNo;
    public Sprite weaponPic;
    public Image weaponDisplay;
    public string weaponName;
    public Text nameDisplay;
    public Text ammoDisplay;
    public Text ammoMax;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ScrolInt == 1)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
        }
        if(ScrolInt == 2)
        {
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }
        if(ScrolInt <= 0)
        {
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
        }
        if(ScrolInt >= maxWeapon)
        {
            ScrolInt = maxWeapon;
        }
        if(Input.GetAxis ("Mouse ScrollWheel") > 0f)
        {
            ScrolInt += 1;
        }
        if(Input.GetAxis ("Mouse ScrollWheel") < 0f)
        {
            ScrolInt -= 1;
        }
        if(ScrolInt > 2)
            ScrolInt = 2;
        if(ScrolInt < 0)
            ScrolInt = 0;
    }
}
