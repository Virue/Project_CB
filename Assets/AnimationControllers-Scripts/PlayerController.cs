using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Stats
{
    public float Player_Min_MP;
    public float Player_Max_MP;
    public float ammoCount;
    public float ammoCountMax;
    public float Player_DR;
    public float Player_Vuln;
    public float Player_Luck;
    public float Player_LifeSteal;
    public float Player_ManaSap;
    public float Player_DS;
    public float Player_MPR;
    public float Player_Min_HP;
    public float Player_Max_HP;
    public float Player_MS;
    // Start is called before the first frame update
    void Start()
    {
        Player_Min_MP = 40;
        Player_Max_MP = 40;
        Player_Min_HP= health = 50;
        Player_Max_HP = maxHealth = 50;
        ammoCount = 0;
        ammoCountMax= 0;
        Player_DR = 0;
        Player_Vuln = 0;
        Player_Luck = 0;
        Player_LifeSteal = 0;
        Player_ManaSap = 0;
        Player_DS = 0;
    }
    public void ManaRegen()
    {
        if (Player_MPR > 0)
        {
            Player_MPR -= Time.deltaTime;
        }
        if (Player_Min_MP != Player_Max_MP && Player_MPR <= 0)
        {
            Player_Min_MP += 1;
            Player_MPR = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
