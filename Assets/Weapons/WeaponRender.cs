using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRender : MonoBehaviour
{
    
    public GameObject SwordRender;
    public GameObject AxeRender;
    public GameObject MaceRender;
    public GameObject BowRender;
    public GameObject WandRender;
    public GameObject StaffRender;
    public float weaponPicker;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponPicker = Random.Range(0, 100);
        Debug.Log("Weapon Number: "+ weaponPicker);
        SwordRender = GameObject.Find("Sword");
        AxeRender = GameObject.Find("Axe");
        MaceRender = GameObject.Find("Mace");
        BowRender = GameObject.Find("Bow");
        WandRender = GameObject.Find("Wand");
        StaffRender = GameObject.Find("Staff");
        if (weaponPicker > 84)
        {
            SwordRender.SetActive(true);
            AxeRender.SetActive(false);
            MaceRender.SetActive(false);
            BowRender.SetActive(false);
            WandRender.SetActive(false);
            StaffRender.SetActive(false);
        }
        else if (weaponPicker > 68)
        {
            SwordRender.SetActive(false);
            AxeRender.SetActive(true);
            MaceRender.SetActive(false);
            BowRender.SetActive(false);
            WandRender.SetActive(false);
            StaffRender.SetActive(false);
        }
        else if (weaponPicker > 52)
        {
            SwordRender.SetActive(false);
            AxeRender.SetActive(false);
            MaceRender.SetActive(true);
            BowRender.SetActive(false);
            WandRender.SetActive(false);
            StaffRender.SetActive(false);
        }
        else if (weaponPicker > 36)
        {
            SwordRender.SetActive(false);
            AxeRender.SetActive(false);
            MaceRender.SetActive(false);
            BowRender.SetActive(true);
            WandRender.SetActive(false);
            StaffRender.SetActive(false);
        }
        else if (weaponPicker > 20)
        {
            SwordRender.SetActive(false);
            AxeRender.SetActive(false);
            MaceRender.SetActive(false);
            BowRender.SetActive(false);
            WandRender.SetActive(true);
            StaffRender.SetActive(false);
        }
        else
        {
            SwordRender.SetActive(false);
            AxeRender.SetActive(false);
            MaceRender.SetActive(false);
            BowRender.SetActive(false);
            WandRender.SetActive(false);
            StaffRender.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
