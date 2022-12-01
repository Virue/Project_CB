using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoonStats : MonoBehaviour
{
    //Blessing variables
    public float Blessing_Player_HP;
    public float Blessing_Player_Max_HP;
    public float Blessing_Player_MP;
    public float Blessing_Player_Max_MP;
    public float Blessing_Player_Attack;
    public float Blessing_Player_Burn;
    public float Blessing_Player_Slow;
    public float Blessing_Player_ManaCost;
    public float Blessing_Player_Ammo;
    public float Blessing_Player_Damage_Reduction;
    public float Blessing_Player_Vulnerable;
    public float Blessing_Player_LifeSteal;
    public float Blessing_Player_ManaSap;
    public float Blessing_Player_MoveSpeed;
    public float Blessing_Player_DoubleStrike;
    public float Blessing_Enemy_Max_HP; // nerf to enemy hp
    public float Blessing_Enemy_Damage; // nerf to enemy DMG
    public float Blessing_Player_Luck;
    //curse variables
    public float Curse_Player_HP;
    public float Curse_Player_Max_HP;
    public float Curse_Player_MP;
    public float Curse_Player_Max_MP;
    public float Curse_Player_Attack;
    public float Curse_Player_Burn;
    public float Curse_Player_Slow;
    public float Curse_Player_ManaCost;
    public float Curse_Player_Ammo;
    public float Curse_Player_Damage_Reduction;
    public float Curse_Player_Vulnerable;
    public float Curse_Player_LifeSteal;
    public float Curse_Player_ManaSap;
    public float Curse_Player_MoveSpeed;
    public float Curse_Player_DoubleStrike;
    public float Curse_Enemy_Max_HP; // buffs to enemy hp
    public float Curse_Enemy_Damage; // buffs to enemy DMG
    public float Curse_Player_Luck;

    public float BoonNum;
    public float groupNum;
    public String blessingText;
    public String curseText;
    
    // Start is called before the first frame update
    void Start()
    {
    Blessing_Player_HP=0;
    Blessing_Player_Max_HP = 0;
    Blessing_Player_MP = 0;
    Blessing_Player_Max_MP = 0 ;
    Blessing_Player_Attack = 0;
    Blessing_Player_Burn = 0;
    Blessing_Player_Slow = 0;
    Blessing_Player_ManaCost = 0;
    Blessing_Player_Ammo = 0;
    Blessing_Player_Damage_Reduction = 0;
    Blessing_Player_Vulnerable = 0;
    Blessing_Player_LifeSteal = 0;
    Blessing_Player_ManaSap = 0;
    Blessing_Player_MoveSpeed = 0;
    Blessing_Player_DoubleStrike=0;
    Blessing_Enemy_Max_HP=0; // nerf to enemy hp
    Blessing_Enemy_Damage=0; // nerf to enemy DMG
    Blessing_Player_Luck=0;
    blessingText = "";
    curseText = "";
}
    // Update is called once per frame
    void Update()
    {
        
}
    public void Reset()
    {
        Blessing_Player_HP = 0;
        Blessing_Player_Max_HP = 0;
        Blessing_Player_MP = 0;
        Blessing_Player_Max_MP = 0;
        Blessing_Player_Attack = 0;
        Blessing_Player_Burn = 0;
        Blessing_Player_Slow = 0;
        Blessing_Player_ManaCost = 0;
        Blessing_Player_Ammo = 0;
        Blessing_Player_Damage_Reduction = 0;
        Blessing_Player_Vulnerable = 0;
        Blessing_Player_LifeSteal = 0;
        Blessing_Player_ManaSap = 0;
        Blessing_Player_MoveSpeed = 0;
        Blessing_Player_DoubleStrike = 0;
        Blessing_Enemy_Max_HP = 0; // nerf to enemy hp
        Blessing_Enemy_Damage = 0; // nerf to enemy DMG
        Blessing_Player_Luck = 0;
        Curse_Player_HP = 0;
        Curse_Player_Max_HP = 0;
        Curse_Player_MP = 0;
        Curse_Player_Max_MP = 0;
        Curse_Player_Attack = 0;
        Curse_Player_Burn = 0;
        Curse_Player_Slow = 0;
        Curse_Player_ManaCost = 0;
        Curse_Player_Ammo = 0;
        Curse_Player_Damage_Reduction = 0;
        Curse_Player_Vulnerable = 0;
        Curse_Player_LifeSteal = 0;
        Curse_Player_ManaSap = 0;
        Curse_Player_MoveSpeed = 0;
        Curse_Player_DoubleStrike = 0;
        Curse_Enemy_Max_HP = 0; // buffs to enemy hp
        Curse_Enemy_Damage = 0; // buffs to enemy DMG
        Curse_Enemy_Damage = 0; // buffs to enemy DMG
        Curse_Enemy_Damage = 0; // buffs to enemy DMG
        Curse_Player_Luck = 0;
        blessingText = " ";
        curseText = " ";
    }
    public String getBlessing()
    {
        
        BoonNum = Random.Range(0, 100);
        if (BoonNum>90)
        {
            Debug.Log("Called function G10");
           
            groupNum = Random.Range(0, 100);
            if (groupNum > 50)
            {
                Blessing_Enemy_Max_HP += Random.Range(5, 25); //percent
                blessingText = "Player Mana Cost Down:  " + Blessing_Player_ManaCost;
            }
            else
            {
                Blessing_Enemy_Damage += Random.Range(1, 15); //percent
                blessingText = "Player Mana Cost Down: " + Blessing_Player_ManaCost;
            }
            return blessingText;
        }
        else if (BoonNum > 70)
        {
            Debug.Log("Pull from group G9");
            if (BoonNum > 78)
            {
             
                Debug.Log("Pull from group G7");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Blessing_Player_Damage_Reduction += Random.Range(1, 80); //percent
                    blessingText = "Player takes less damage + " + Blessing_Player_Damage_Reduction;
                }
                else
                {
                    Blessing_Player_Vulnerable += Random.Range(1, 75);//percent
                    blessingText = "Player deals more damage " + Blessing_Player_Vulnerable;
                }
                return blessingText;
            }
            else
            {
                Debug.Log("Pull from group G8");
                groupNum = Random.Range(0, 100);
                if (groupNum > 75)
                {
                    groupNum = Random.Range(0, 100);
                    if (groupNum > 50)
                    {
                        Blessing_Player_LifeSteal += Random.Range(5, 25);
                        blessingText = "Player LifeSteal on hit: " + Blessing_Player_LifeSteal + " %";
                    }
                    else
                    {
                        Blessing_Player_LifeSteal += Random.Range(2, 10);// percent
                        blessingText = "Player Lifesteal on Hit " + Blessing_Player_LifeSteal+" %";
                    }
                }
                else if (groupNum > 50)
                {
                    groupNum = Random.Range(0, 100);
                    if (groupNum > 50)
                    {
                        Blessing_Player_ManaSap += Random.Range(5, 30);
                        blessingText = "Player Steals Mana: " + Blessing_Player_ManaSap + " %";
                    }
                    else
                    {
                        Blessing_Player_ManaSap += Random.Range(1, 15);//percent
                        blessingText = "Player Steals Mana: " + Blessing_Player_ManaSap+" %";
                    }
                }
                else if (groupNum > 25)
                {
                    Blessing_Player_MoveSpeed += Random.Range(1, 20);// percent
                    blessingText = "Player Movespeed increased " + Blessing_Player_MoveSpeed + " %";
                }
                else
                {
                    Blessing_Player_DoubleStrike += Random.Range(15, 60); // percent
                    blessingText = "Player chance to hit twice" + Blessing_Player_DoubleStrike + " %";
                }
                return blessingText;
            }
           
        }
        else if (BoonNum > 40)
        {
            Debug.Log("Pull from group G6");
            if (BoonNum > 59)
            {
                Debug.Log("Pull from group G4");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Blessing_Player_Burn += Random.Range(1, 15);//percent
                    blessingText = "Player Deals burn damage also: " + Blessing_Player_Burn + "%";
                }
                else
                {
                    Blessing_Player_ManaCost += Random.Range(1, 20);//percent
                    blessingText = "Player Mana Cost reduced + " + Blessing_Player_ManaCost + "%";
                }
                return blessingText;
            }
            else
            {
                Debug.Log("Pull from group G5");
                groupNum = Random.Range(0, 100);
                if (groupNum > 66)
                {
                    Blessing_Player_Attack += Random.Range(5, 200);
                    blessingText = "Player Base Attack: " + Blessing_Player_Attack;
                }
                else if (groupNum > 33)
                {
                    Blessing_Player_Attack += Random.Range(5, 30);//percent
                    blessingText = "Player Base Attack : " + Blessing_Player_Attack+"%";
                }
                else
                {
                    Blessing_Player_Slow += Random.Range(1, 20);//percent
                    blessingText = "Player Slows Enemies on hit: " + Blessing_Player_Slow+" %";
                }
                return blessingText;
            }
        }
        else if (BoonNum > 35)
        {
            Debug.Log("Pull from group G11");
            Blessing_Player_Luck += Random.Range(1, 5);
            blessingText = "Player Luck: + " + Blessing_Player_Luck;
            return blessingText;
            //  return blessingText;
        }
        else if (BoonNum > 0)
        {
            Debug.Log("Pull from group G3");
            if (BoonNum > 17)
            {
                Debug.Log("Pull from group G1");
                groupNum = Random.Range(0, 100);
                if (groupNum > 75)
                {
                    Blessing_Player_HP += Random.Range(15, 50);
                    blessingText = "Player HP: + " + Blessing_Player_HP;
                }
                else if (groupNum > 50)
                {
                    Blessing_Player_HP += Random.Range(5, 20);//percent
                    blessingText = "Player HP: + " + Blessing_Player_HP + "%";
                }
                else if (groupNum > 25)
                {
                    Blessing_Player_Max_HP += Random.Range(10, 100);
                    blessingText = "Player MaxHP: + " + Blessing_Player_HP;
                }
                else
                {
                    Blessing_Player_Max_HP += Random.Range(10, 50);//percent
                    blessingText = "Player MaxHP: + " + Blessing_Player_HP + "%";
                }
                return blessingText;
            }
            else
            {
                Debug.Log("Pull from group G2");
                groupNum = Random.Range(0, 100);
                if (groupNum > 75)
                {
                    Blessing_Player_MP += Random.Range(15, 60);
                    blessingText = "Player MP: + " + Blessing_Player_HP;
                }
                else if (groupNum > 50)
                {
                    Blessing_Player_MP += Random.Range(5, 40);//percent
                    blessingText = "Player MP: + " + Blessing_Player_HP + "%";
                }
                else if (groupNum > 25)
                {
                    Blessing_Player_Max_MP += Random.Range(10, 100);
                    blessingText = "Player Max MP: + " + Blessing_Player_HP;
                }
                else
                {
                    Blessing_Player_Max_MP += Random.Range(5, 30);//percent
                    blessingText = "Player Max MP: + " + Blessing_Player_HP + "%";
                }
                return blessingText;
            }
        }
        return blessingText;
    }

    public String getCurse()
    {
        BoonNum = Random.Range(0, 100);
        if (BoonNum > 2 && BoonNum <5)
        {
            Debug.Log("Pull from group G10");
            groupNum = Random.Range(0, 100);
            if (groupNum > 50)
            {
                Curse_Enemy_Max_HP += Random.Range(5, 15);//percent
                curseText = "Player Max HP Down:  " + Curse_Enemy_Max_HP+"%";
            }
            else
            {
                Curse_Enemy_Damage += Random.Range(1, 15);//percent
                curseText = "Enemy Damage up :  " + Curse_Enemy_Damage + "%";
            }
            return curseText;
        }
        else if (BoonNum > 90)
        {
            Debug.Log("Pull from group G9");
            if (BoonNum > 95)
            {
                Debug.Log("Pull from group G7");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Curse_Player_Damage_Reduction += Random.Range(5, 15);//percent
                    curseText = "Player Deals less damage" + Curse_Player_Damage_Reduction+"%";
                }
                else
                {
                    Curse_Player_Vulnerable += Random.Range(1, 15);//percent
                    curseText = "Player Takes more damage:  " + Curse_Player_Vulnerable+"%";
                }
                return curseText;
            }
            else
            {
                Debug.Log("Pull from group G8");
                groupNum = Random.Range(0, 100);
                if (groupNum > 75)
                {
                    Curse_Player_LifeSteal += Random.Range(1, 90);//percent
                    curseText = "Player loses lifesteal stat " + Curse_Player_LifeSteal+"%";
                }
                else if (groupNum > 50)
                {
                    Curse_Player_ManaSap += Random.Range(1, 80);//percent
                    curseText = "Player Loses manasap stat:  " + Curse_Player_ManaSap + "%";
                }
                else if (groupNum > 25)
                {
                    Curse_Player_MoveSpeed += Random.Range(1, 7);//percent
                    curseText = "Player Gets slowed down:  " + Curse_Player_MoveSpeed + "%";
                }
                else
                {
                    Curse_Player_DoubleStrike += Random.Range(1, 10);//percent
                    curseText = "Player loses some chance to double strike:" + Curse_Player_DoubleStrike + "%";
                }
                return curseText;
            }
        }
        else if (BoonNum > 5 && BoonNum <20)
        {
            Debug.Log("Pull from group G6");
            if (BoonNum > 59)
            {
                Debug.Log("Pull from group G4");
                groupNum = Random.Range(0, 100);
                if (groupNum > 66)
                {
                    Curse_Player_Burn += Random.Range(1, 90);//percent
                    curseText = "Player takes burn damage on hit?:  " + Curse_Player_Burn + "%";
                }
                else if (groupNum > 33)
                {
                    Curse_Player_Slow += Random.Range(1, 90);//percent
                    curseText = "Player Slows down on hit" + Curse_Player_Slow + "%";
                }
                else
                {
                    Curse_Player_ManaCost += Random.Range(1, 90);//percent
                    curseText = "Increase mana costs: " + Curse_Player_ManaCost + "%";
                }
                return curseText;
            }
            else
            {
                Debug.Log("Pull from group G5");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Curse_Player_Attack += Random.Range(1, 90);//percent
                    curseText = "Player base Attack down  " + Curse_Player_Attack+"%";
                }
                else
                {
                    Curse_Player_Ammo += Random.Range(1, 90);//percent
                    curseText = "Player loses Ammo: " + Curse_Player_Ammo+"%";
                }
                return curseText;
            }
        }
        else if (BoonNum > 0 && BoonNum <2)
        {
            Debug.Log("Pull from group G11");
            Curse_Player_Luck += Random.Range(1, 90);//percent
            curseText = "Player Loses Luck: " + Curse_Player_Luck+"%";
            return curseText;
        }
        else if (BoonNum > 80 && BoonNum<90)
        {
            Debug.Log("Pull from group G3");
            if (BoonNum > 17)
            {
                Debug.Log("Pull from group G1");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Curse_Player_HP += Random.Range(1, 90);//percent
                    curseText = "Player loses hp: " + Curse_Player_HP+"%";
                }
                else
                {
                    Curse_Player_Max_HP += Random.Range(1, 90);//percent
                    curseText = "Player Mana Cost Down:  " + Curse_Player_Max_HP + "%";
                }
                return curseText;
            }
            else
            {
                Debug.Log("Pull from group G2");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Curse_Player_MP += Random.Range(1, 90);//percent
                    curseText = "Player loses Mana " + Curse_Player_MP + "%";
                }
                else
                {
                    Curse_Player_Max_MP += Random.Range(1, 90);//percent
                    curseText = "Player Loses max mana: " + Curse_Player_Max_MP+"%";
                }
                return curseText;
            }
            
        }
        else
        {
            curseText = "The Goddess shines down on you";
            return curseText;
        }
    }

}
