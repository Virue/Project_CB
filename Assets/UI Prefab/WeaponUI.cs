using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    WeaponStats weaponStats;
    public TextMeshProUGUI Weapon1;
    public TextMeshProUGUI Weapon2;
    public TextMeshProUGUI newWeapon;
    public GameObject panel;//weaponTrade
    //attack
    public TextMeshProUGUI Attack;
    //bleed
    public TextMeshProUGUI Bleed;
    //vuln
    public TextMeshProUGUI Vuln;
    //dr
    public TextMeshProUGUI DR;
    //g1//r1
    public TextMeshProUGUI g1;
    //g1/g2//r1
    public TextMeshProUGUI g1g2;
    //g5 //r2
    public TextMeshProUGUI g5;
    //g3/g4//r3
    public TextMeshProUGUI g3g4;
    //g7/g6 //range
    public TextMeshProUGUI range;
    //rank
    public TextMeshProUGUI rank;
    // Start is called before the first frame update
    void Start()
    {
        weaponStats = gameObject.AddComponent<WeaponStats>();
        // panel = transform.Find("WeaponTrade").gameObject as GameObject;
        weaponStats.Weapon_Rank = Random.Range(1, 3);
        //weaponStats.weaponType = Random.Range(1,2);
        weaponStats.weaponType = 2;
        if (weaponStats.weaponType == 1)
        {
            weaponStats.Melee();
            rank.text = "rank:" + weaponStats.Weapon_Rank;
            Attack.text = "Attack:" + weaponStats.Weapon_Attack;
            Bleed.text = "Bleed:" + weaponStats.Weapon_Bleed;
            Vuln.text = "Vuln: " + weaponStats.Weapon_Vulnerable;
            DR.text = "Dr:" + weaponStats.Weapon_DamageReduction;
            g1.text = "" + weaponStats.statGroup1Str;
            g1g2.text = "" + weaponStats.WeaponStatGroup1;
            g5.text = "" + weaponStats.statGroup5Str;
            g3g4.text = "" + weaponStats.WeaponStatGroup2;
            range.text = "";
        }
        else
        {
            weaponStats.Range();
            rank.text = "rank:" + weaponStats.Weapon_Rank;
            Attack.text = "Attack:" + weaponStats.Weapon_Attack;
            Bleed.text = "Bleed:" + weaponStats.Weapon_Bleed;
            Vuln.text = "Vuln: " + weaponStats.Weapon_Vulnerable;
            DR.text = "Dr:" + weaponStats.Weapon_DamageReduction;
            g1.text = "" + weaponStats.statGroup1Str;
            g1g2.text = "" + weaponStats.WeaponStatGroup1;
            g5.text = "" + weaponStats.statGroup5Str;
            g3g4.text = "" + weaponStats.WeaponStatGroup2;
            range.text = "r:"+weaponStats.statGroup7Str;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //pull player weapon1
        //pull player weapon2
        //roll new weapon
        //check if q or e is press
        //q takes the weapon
        //e doesnt
        //q and e hides the weapon trade UI
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Q))
        {
            panel.SetActive(false);
        }
    }
}
