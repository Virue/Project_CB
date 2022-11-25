using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    //static
    public float Weapon_Attack;
    public float Weapon_Luck;
    public float Weapon_MoveSpeed;
    public float Weapon_Max_HP;
    public float Weapon_Max_MP;
    public float Weapon_Ammo;
    public float Weapon_Slow;
    public float Weapon_Burn;
    public float Weapon_ManaCost;
    //onHit proc
    public float Weapon_LifeSteal;
    public float Weapon_ManaSap;
    public float Weapon_DoubleStrike;
    //OnKill proc
    public float Weapon_OnKill_Max_HP;
    public float Weapon_OnKill_Max_MP;
    public float Weapon_OnKill_Min_HP;
    public float Weapon_OnKill_Min_MP;
    public float Weapon_OnKill_MoveSpeed;

    public float Weapon_Bleed;

    public float Weapon_Rank;
    public float Weapon_Stat_Group;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* Should i just make the whole list or just what goes into the ranks and 
     * make them specific for what type? melee or Range(->) bow/magic
     * then after weaponStat is done make melee weapons -> range weapons by name like
     * get RapierStats pass in Weapon_Rank  for the rankings and random stats
    */
    public void GetWeaponStat(float r)
    {
        Weapon_Rank = r;
        if (Weapon_Rank==1)
        {

        }else if (Weapon_Rank == 2)
        {

        }else if (Weapon_Rank == 3)
        {

        }
    }

}
