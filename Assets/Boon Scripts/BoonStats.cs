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
    public float blessingNum;
    public float curseNum;
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

        }else if (BoonNum > 70)
        {
            Debug.Log("Pull from group G9");
            if (BoonNum > 78)
            {
                Debug.Log("Pull from group G7");
            }
            else
            {
                Debug.Log("Pull from group G8");
            }
        }
        else if (BoonNum > 40)
        {
            Debug.Log("Pull from group G6");
            if (BoonNum > 59)
            {
                Debug.Log("Pull from group G4");
            }
            else
            {
                Debug.Log("Pull from group G5");
            }
        }
        else if (BoonNum > 35)
        {
            Debug.Log("Pull from group G11");
        }
        else if (BoonNum > 0)
        {
            Debug.Log("Pull from group G3");
            if (BoonNum > 17)
            {
                Debug.Log("Pull from group G1");
            }
            else
            {
                Debug.Log("Pull from group G2");
            }
        }
    }
    public void getCurse()
    {
        BoonNum = Random.Range(0, 100);
        if (BoonNum > 90)
        {
            Debug.Log("Pull from group G10");

        }
        else if (BoonNum > 70)
        {
            Debug.Log("Pull from group G9");
            if (BoonNum > 78)
            {
                Debug.Log("Pull from group G7");
            }
            else
            {
                Debug.Log("Pull from group G8");
            }
        }
        else if (BoonNum > 40)
        {
            Debug.Log("Pull from group G6");
            if (BoonNum > 59)
            {
                Debug.Log("Pull from group G4");
            }
            else
            {
                Debug.Log("Pull from group G5");
            }
        }
        else if (BoonNum > 35)
        {
            Debug.Log("Pull from group G11");
        }
        else if (BoonNum > 0)
        {
            Debug.Log("Pull from group G3");
            if (BoonNum > 17)
            {
                Debug.Log("Pull from group G1");
            }
            else
            {
                Debug.Log("Pull from group G2");
            }
        }
    }

}
