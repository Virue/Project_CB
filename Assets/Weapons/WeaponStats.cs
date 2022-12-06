using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

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
    public float Weapon_DamageReduction;
    public float Weapon_Vulnerable;
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
    public float weaponType;
    public float Weapon_Stat_Group;
    public float Weapon_RandomPicker;
    public float Weapon_StatGroup1;
    public float Weapon_StatGroup2;
    public float Weapon_StatGroup3;
    public String statGroup1Str;
    public String statGroup2Str;
    public String statGroup3Str;
    public String statGroup4Str;
    public String statGroup5Str;
    public String statGroup6Str;
    public String statGroup7Str;
    public String WeaponStatGroup1;
    public String WeaponStatGroup2;
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
    // do getSingleStat(Weapon_rank) 
    public void GetWeaponAttack()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Attack += Random.Range(3, 6);
           
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Attack += Random.Range(10, 15);
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Attack += Random.Range(19, 24);
        }
        statGroup1Str = "Atk up: " + Weapon_Attack;
    }
    public void GetWeaponLuck()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Luck += Random.Range(1, 3);
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Luck += Random.Range(3, 5);
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Luck += Random.Range(5, 7);
        }
        statGroup1Str = "Luck up: " + Weapon_Luck;
    }
    public void GetWeaponMoveSpeed()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_MoveSpeed += Random.Range(1, 3);
        }
        if (Weapon_Rank == 2)
        {
            Weapon_MoveSpeed += Random.Range(4, 6);
        }
        if (Weapon_Rank == 3)
        {
            Weapon_MoveSpeed += Random.Range(7, 10);
        }
        statGroup1Str = "MS up: " + Weapon_MoveSpeed;
    }
    public void GetWeaponMHP()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Max_HP += Random.Range(15, 30);
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Max_HP += Random.Range(30, 45);
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Max_HP += Random.Range(45, 50);
        }
        statGroup2Str = "Max HP up: " + Weapon_Max_HP;
    }
    public void GetWeaponMMP()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Max_MP += Random.Range(20, 40);
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Max_MP += Random.Range(40, 50);
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Max_MP += Random.Range(50, 60);
        }
        statGroup2Str = "Max MP up: " + Weapon_Max_MP;
    }
    public void GetWeaponAmmo()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Ammo += 5;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Ammo += 10;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Ammo += 15;
        }
        statGroup6Str = "Ammo up: " + Weapon_Ammo;
    }
    public void GetWeaponSlow()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Slow += 5;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Slow += 6;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Slow += 7;
        }
        statGroup6Str = "Slow up: " + Weapon_Slow;
        statGroup7Str = "Slow up: " + Weapon_Slow;
    }
    public void GetWeaponBurn()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_Burn += 3;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_Burn += 5;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_Burn += 8;
        }
        statGroup6Str = "Burn up: " + Weapon_Burn;
        statGroup7Str = "Slow up: " + Weapon_Burn;
    }
    public void GetWeaponManaCost()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_ManaCost -= 1;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_ManaCost -= 2;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_ManaCost -= 3;
        }
        statGroup7Str = "MC down: " + Weapon_ManaCost;
    }
    public void GetWeaponOnHitLifeSteal()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_LifeSteal += 3;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_LifeSteal += 10;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_LifeSteal += 1;// 1 % of MHP
        }
        statGroup3Str = "LS up: " + Weapon_LifeSteal;
        statGroup5Str = "LS up: " + Weapon_LifeSteal;
    }
    public void GetWeaponOnHitManaSap()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_ManaSap += 4;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_ManaSap += 6;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_ManaSap += 8;
        }
        statGroup3Str = "ManaSap up: " + Weapon_ManaSap;
        statGroup5Str = "ManaSap up: " + Weapon_ManaSap;
    }
    public void GetWeaponOnHitDoubleStrike()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_DoubleStrike += Random.Range(5, 15);
        }
        if (Weapon_Rank == 2)
        {
            Weapon_DoubleStrike += Random.Range(20, 30);
        }
        if (Weapon_Rank == 3)
        {
            Weapon_DoubleStrike += Random.Range(70, 90);
        }
        statGroup3Str = "DS up: " + Weapon_DoubleStrike;
        statGroup5Str = "DS up: " + Weapon_DoubleStrike;
    }
    public void GetWeaponOnKillMHP()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_OnKill_Max_HP += 2;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_OnKill_Max_HP += 6;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_OnKill_Max_HP += 10;
        }
        statGroup4Str = "Onkill Max HP up: " + Weapon_OnKill_Max_HP;
        statGroup5Str = "Onkill Max HP up: " + Weapon_OnKill_Max_HP;
    }
    public void GetWeaponOnKillMMP()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_OnKill_Max_MP += 1;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_OnKill_Max_MP += 3;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_OnKill_Max_MP += 5;
        }
        statGroup4Str = "Onkill Max MP up: " + Weapon_OnKill_Max_MP;
        statGroup5Str = "Onkill Max MP up: " + Weapon_OnKill_Max_MP;
    }
    public void GetWeaponOnKillHP()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_OnKill_Min_HP += 4;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_OnKill_Min_HP += 16;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_OnKill_Min_HP += 28;
        }
        statGroup4Str = "Heal on Kill: " + Weapon_OnKill_Min_HP;
        statGroup5Str = "Heal on Kill: " + Weapon_OnKill_Min_HP;
    }
    public void GetWeaponOnKillMP()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_OnKill_Min_MP += 2;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_OnKill_Min_MP += 8;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_OnKill_Min_MP += 14;
        }
        statGroup4Str = "Regen on Kill: " + Weapon_OnKill_Min_MP;
        statGroup5Str = "Regen on Kill: " + Weapon_OnKill_Min_MP;
    }
    public void GetWeaponOnKillMoveSpeed()
    {
        if (Weapon_Rank == 1)
        {
            Weapon_OnKill_MoveSpeed += 25;
        }
        if (Weapon_Rank == 2)
        {
            Weapon_OnKill_MoveSpeed += 50;
        }
        if (Weapon_Rank == 3)
        {
            Weapon_OnKill_MoveSpeed += 150;
        }
        statGroup4Str = "MS on Kill: " + Weapon_OnKill_Min_MP+"%";
        statGroup5Str = "MS on Kill: " + Weapon_OnKill_Min_MP+"%";
    }

    //stat grouping
    //g1
    public void StatGroup1()
    {
        if (Weapon_RandomPicker > 66)
        {
            GetWeaponAttack();
        }
        else if (Weapon_RandomPicker > 33)
        {
            GetWeaponLuck();
        }
        else
        {
            GetWeaponMoveSpeed();
        }
    }
    //g2
    public void StatGroup2()
    {

        if (Weapon_RandomPicker > 50)
        {
            GetWeaponMHP();
        }
        else
        {
            GetWeaponMMP();
        }
    }
    //g3
    public void StatGroup3()
    {
        if (Weapon_RandomPicker > 66)
        {
            GetWeaponOnHitLifeSteal();
        }
        else if (Weapon_RandomPicker > 33)
        {
            GetWeaponOnHitManaSap();
        }
        else
        {
            GetWeaponOnHitDoubleStrike();
        }
    }
    //g4
    public void StatGroup4()
    {
        if (Weapon_RandomPicker > 80)
        {
            GetWeaponOnKillMHP();
        }
        else if (Weapon_RandomPicker > 60)
        {
            GetWeaponOnKillMMP();
        }
        else if (Weapon_RandomPicker > 40)
        {
            GetWeaponOnKillHP();
        }
        else if (Weapon_RandomPicker > 20)
        {
            GetWeaponOnKillMP();
        }
        else
        {
            GetWeaponOnKillMoveSpeed();
        }
    }
    //g5
    public void StatGroup5()
    {

        if (Weapon_RandomPicker > 88)
        {
            GetWeaponOnHitLifeSteal();
        }
        else if (Weapon_RandomPicker > 76)
        {
            GetWeaponOnHitManaSap();
        }
        else if (Weapon_RandomPicker > 64)
        {
            GetWeaponOnHitDoubleStrike();
        }
        else if (Weapon_RandomPicker > 52)
        {
            GetWeaponOnKillMHP();
        }
        else if (Weapon_RandomPicker > 40)
        {
            GetWeaponOnKillMMP();
        }
        else if (Weapon_RandomPicker > 28)
        {
            GetWeaponOnKillHP();
        }
        else if (Weapon_RandomPicker > 12)
        {
            GetWeaponOnKillMP();
        }
        else
        {
            GetWeaponOnKillMoveSpeed();
        }
    }
    //g6
    public void StatGroup6()
    {

        if (Weapon_RandomPicker > 66)
        {
            GetWeaponAmmo();
        }
        else if (Weapon_RandomPicker > 33)
        {
            GetWeaponSlow();
        }
        else
        {
            GetWeaponBurn();
        }
    }
    //g7
    public void StatGroup7()
    {

        if (Weapon_RandomPicker > 66)
        {
            GetWeaponSlow();
        }
        else if (Weapon_RandomPicker > 33)
        {
            GetWeaponBurn();
        }
        else
        {
            GetWeaponManaCost();
        }
    }
    //melee
    public void WeaponStat1()
    {
        StatGroup1();
        Weapon_RandomPicker = Random.Range(0, 100);
        if (Weapon_RandomPicker > 50)
        {
            StatGroup1();
            WeaponStatGroup1 += statGroup1Str;
        }
        else
        {
            StatGroup2();
            WeaponStatGroup1 +=statGroup2Str;
        }

    }
    public void WeaponStat2()
    {
        WeaponStat1();
        StatGroup5();
    }
    public void WeaponStat3()
    {
        WeaponStat2();
        Weapon_RandomPicker = Random.Range(0, 100);
        if (Weapon_RandomPicker > 50)
        {
            StatGroup3();
            WeaponStatGroup2 += statGroup3Str;
        }
        else
        {
            StatGroup4();
            WeaponStatGroup2 += statGroup4Str;
        }
    }
    public void MeleeStat()
    {
        /* rank 1 G1, (G1 or G2)
         * Rank 2 rank1, G5
         * Rank 3 rank2, (G3 or G4)
         */
        if (Weapon_Rank == 1)
        {
            WeaponStat1();
        }
        if (Weapon_Rank == 2)
        {
            WeaponStat2();
        }
        if (Weapon_Rank == 3)
        {
            WeaponStat3();
        }

    }
    //range
    public void RangeStat()
    {
        /* use MeleeStat() here for RANK 1-3
         * 
         */
        if (Weapon_Rank == 1)
        {
            WeaponStat1();
        }
        if (Weapon_Rank == 2)
        {
            WeaponStat2();
        }
        if (Weapon_Rank == 3)
        {
            WeaponStat3();
        }
    }
    //bow
    public void BowStat()
    {
        /* Rank1 rangeStat(1), G7 
         * Rank2 RangeStat(2),G7
         * Rank3 RangeStat(3), G7
         */
        RangeStat();
        StatGroup7();
    }
    //magic
    public void MagicStat()
    {
        /* Rank1 rangeStat(1), G6 
         * Rank2 RangeStat(2),G6
         * Rank3 RangeStat(3), G6
         */
        RangeStat();
        StatGroup6();
    }
    /* time to do each weapon stats they come with */
    //weapon stats to then break down
   
    public void Melee()
    {
       // if (gameObject.tag=="Rapier")
       // {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = Random.Range(5,8);
                Weapon_DamageReduction = 0.03f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = Random.Range(11, 14);
                Weapon_DamageReduction = 0.06f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = Random.Range(17, 23);
                Weapon_DamageReduction = 0.09f;
            }
      //  }
        if (gameObject.tag == "Sword")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = Random.Range(4, 9);
                Weapon_Bleed= Random.Range(1, 2);
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = Random.Range(10, 15);
                Weapon_Bleed = Random.Range(1, 4);
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = Random.Range(16, 21);
                Weapon_Bleed = Random.Range(1, 6);
            }
        }
        if (gameObject.tag == "Dagger")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = Random.Range(4, 9);
                Weapon_Bleed= 7;
                Weapon_DamageReduction= 0.04f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = Random.Range(4, 9);
                Weapon_Bleed = 10;
                Weapon_DamageReduction = 0.08f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = Random.Range(4, 9);
                Weapon_Bleed = 13;
                Weapon_DamageReduction = 0.12f;
            }
        }
        if (gameObject.tag == "Halberg")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = Random.Range(10,13);
                Weapon_DamageReduction= 0.02f;
                Weapon_Vulnerable= 0.05f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = Random.Range(15, 18);
                Weapon_DamageReduction = 0.02f;
                Weapon_Vulnerable = 0.06f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = Random.Range(20, 23);
                Weapon_DamageReduction = 0.02f;
                Weapon_Vulnerable = 0.07f;
            }
        }
        if (gameObject.tag == "Spear")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = Random.Range(8, 12);
                Weapon_DamageReduction= 0.08f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = Random.Range(14,18);
                Weapon_DamageReduction = 0.10f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = Random.Range(20, 24);
                Weapon_DamageReduction = 0.12f;
            }
        }
        if (gameObject.tag == "Mace")
        {
           if (Weapon_Rank == 1)
            {

                Weapon_Attack = Random.Range(8, 10);
                Weapon_Vulnerable= 0.09f; 
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = Random.Range(12, 14);
                Weapon_Vulnerable = 0.10f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = Random.Range(16, 18);
                Weapon_Vulnerable = 0.11f;
            }
        }
        if (gameObject.tag == "Club")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 8;
                Weapon_Vulnerable= 0.10f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 13;
                Weapon_Vulnerable = 0.12f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 18;
                Weapon_Vulnerable = 0.15f;
            }
        }
        MeleeStat();
    }
    public void Range()
    {
        
      //  if (gameObject.tag == "fire Bow")
      //  {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 3;
                Weapon_Ammo= 15;
                Weapon_Burn= Random.Range(8,10);
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 7;
                Weapon_Ammo = 20;
                Weapon_Burn = Random.Range(15, 20);
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 12;
                Weapon_Ammo = 25;
                Weapon_Burn = Random.Range(25, 30);
            }
            BowStat();
       // }
        if (gameObject.tag == "Ice Bow")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 5;
                Weapon_Ammo = 10;
                Weapon_Slow = 0.20f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 9;
                Weapon_Ammo = 15;
                Weapon_Slow = 0.40f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 15;
                Weapon_Ammo = 20;
                Weapon_Slow = 0.60f;
            }
            BowStat();
        }
        if (gameObject.tag == "Reg Bow")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 7;
                Weapon_Ammo = 30;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 20;
                Weapon_Ammo = 30;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 40;
                Weapon_Ammo = 30;
            }
            BowStat();
        }
        if (gameObject.tag == "fire Wand")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 8;
                Weapon_ManaCost = 16;
                Weapon_Burn = Random.Range(2,3);
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 16;
                Weapon_ManaCost = 10;
                Weapon_Burn = Random.Range(5,8);
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 24;
                Weapon_ManaCost = 4;
                Weapon_Burn = Random.Range(10, 15);
            }
            MagicStat();
        }
        if (gameObject.tag == "Ice Wand")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 5;
                Weapon_ManaCost = 10;
                Weapon_Slow= 0.05f;
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 10;
                Weapon_ManaCost = 8;
                Weapon_Slow = 0.10f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 15;
                Weapon_ManaCost = 6;
                Weapon_Slow = 0.15f;
            }
            MagicStat();
        }
        if (gameObject.tag == "fire Staff")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 13;
                Weapon_ManaCost = 15;
                Weapon_Burn = Random.Range(5, 6);
            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 28;
                Weapon_ManaCost = 10;
                Weapon_Burn = Random.Range(10, 12);
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 43;
                Weapon_ManaCost = 5;
                Weapon_Burn = Random.Range(16, 22);
            }
            MagicStat();
        }
        if (gameObject.tag == "Ice Staff")
        {
            if (Weapon_Rank == 1)
            {
                Weapon_Attack = 10;
                Weapon_ManaCost = 15;
                Weapon_Slow = 0.10f;

            }
            if (Weapon_Rank == 2)
            {
                Weapon_Attack = 15;
                Weapon_ManaCost = 10;
                Weapon_Slow = 0.30f;
            }
            if (Weapon_Rank == 3)
            {
                Weapon_Attack = 20;
                Weapon_ManaCost = 5;
                Weapon_Slow = 0.50f;
            }
            MagicStat();
        }
      
    }

}
