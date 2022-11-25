using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void getBlessing()
    {
        BoonNum = Random.Range(0, 100);
        if (BoonNum>90)
        {
            Debug.Log("Pull from group G10");
            groupNum= Random.Range(0, 100);
            if (groupNum > 50)
            {
                Blessing_Enemy_Max_HP += Random.Range(5, 25); //percent
            }
            else
            {
                Blessing_Enemy_Damage += Random.Range(1, 15); //percent
            }
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
                }
                else
                {
                    Blessing_Player_Vulnerable += Random.Range(1, 75);//percent
                }
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
                    }
                    else
                    {
                        Blessing_Player_LifeSteal += Random.Range(2, 10);// percent
                    }
                } 
                else if (groupNum >50)
                {
                    groupNum = Random.Range(0, 100);
                    if (groupNum > 50)
                    {
                        Blessing_Player_ManaSap += Random.Range(5, 30);
                    }
                    else
                    {
                        Blessing_Player_ManaSap += Random.Range(1, 15);//percent
                    }
                } 
                else if (groupNum >25) {
                    Blessing_Player_MoveSpeed += Random.Range(1, 20);// percent
                } 
                else {
                    Blessing_Player_DoubleStrike += Random.Range(15, 60); // percent
                }
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
                }
                else
                {
                    Blessing_Player_ManaCost += Random.Range(1, 20);//percent
                }
            }
            else
            {
                Debug.Log("Pull from group G5");
                groupNum = Random.Range(0, 100);
                if (groupNum > 66)
                {
                    Blessing_Player_Attack += Random.Range(5, 200);
                } 
                else if (groupNum >33) {
                    Blessing_Player_Attack += Random.Range(5, 30);//percent
                } 
                else {
                    Blessing_Player_Slow += Random.Range(1, 20);//percent
                }
            }
        }
        else if (BoonNum > 35)
        {
            Debug.Log("Pull from group G11");
            Blessing_Player_Luck += Random.Range(1,5);
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
                }
                else if (groupNum > 50) {
                    Blessing_Player_HP += Random.Range(5, 20);//percent
                }
                else if (groupNum > 25) {
                    Blessing_Player_Max_HP += Random.Range(10, 100);
                }
                else {
                    Blessing_Player_Max_HP += Random.Range(10, 50);//percent
                }
            }
            else
            {
                Debug.Log("Pull from group G2");
                groupNum = Random.Range(0, 100);
                if (groupNum > 75)
                {
                    Blessing_Player_MP += Random.Range(15, 60);
                }
                else if (groupNum>50) {
                    Blessing_Player_MP += Random.Range(5, 40);//percent
                } 
                else if (groupNum > 25) {
                    Blessing_Player_Max_MP += Random.Range(10, 100);
                }
                else {
                    Blessing_Player_Max_MP += Random.Range(5, 30);//percent
                }
            }
        }
    }
    public void getCurse()
    {
        BoonNum = Random.Range(0, 100);
        if (BoonNum > 2 && BoonNum <5)
        {
            Debug.Log("Pull from group G10");
            groupNum= Random.Range(0, 100);
            if (groupNum>50) {
                Curse_Enemy_Max_HP += Random.Range(5, 15);//percent
            }
            else {
                Curse_Enemy_Damage += Random.Range(1, 15);//percent
            }
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
                }
                else
                {
                    Curse_Player_Vulnerable += Random.Range(1, 15);//percent
                }
            }
            else
            {
                Debug.Log("Pull from group G8");
                groupNum = Random.Range(0, 100);
                if (groupNum > 75)
                {
                    Curse_Player_LifeSteal += Random.Range(1, 90);//percent
                }
                else if (groupNum > 50)
                {
                    Curse_Player_ManaSap += Random.Range(1, 80);//percent
                }
                else if (groupNum > 25)
                {
                    Curse_Player_MoveSpeed += Random.Range(1, 7);//percent
                }
                else
                {
                    Curse_Player_DoubleStrike += Random.Range(1, 10);//percent
                }
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
                } 
                else if (groupNum>33) {
                    Curse_Player_Slow += Random.Range(1, 90);//percent
                }
                else {
                    Curse_Player_ManaCost += Random.Range(1, 90);//percent
                }
            }
            else
            {
                Debug.Log("Pull from group G5");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Curse_Player_Attack += Random.Range(1, 90);//percent
                }
                else
                {
                    Curse_Player_Ammo += Random.Range(1, 90);//percent
                }
            }
        }
        else if (BoonNum > 0 && BoonNum <2)
        {
            Debug.Log("Pull from group G11");
            Curse_Player_Luck += Random.Range(1, 90);//percent
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
                }
                else
                {
                    Curse_Player_Max_HP += Random.Range(1, 90);//percent
                }
            }
            else
            {
                Debug.Log("Pull from group G2");
                groupNum = Random.Range(0, 100);
                if (groupNum > 50)
                {
                    Blessing_Player_MP += Random.Range(1, 90);//percent
                }
                else
                {
                    Blessing_Player_Max_MP += Random.Range(1, 90);//percent
                }
            }
        }
       
    }

}
