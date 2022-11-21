using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Stats
{
    public float mana;
    public float maxMana;
    public float ammo;
    public float damageReduction;
    public float vulnerability;
    public float Luck;
    public float lifeSteal;
    public float manaSap;
    public float HitTwice;
    public float Regenreset;
    // Start is called before the first frame update
    void Start()
    {
        mana = 40;
        maxMana = 40;
        health = 50;
        maxHealth = 50;
        ammo = 0;
        damageReduction = 0;
        vulnerability = 0;
        Luck = 0;
        lifeSteal = 0;
        manaSap = 0;
        HitTwice = 0;
    }
    public void ManaRegen()
    {
        if (Regenreset > 0)
        {
            Regenreset -= Time.deltaTime;
        }
        if (mana != maxMana && Regenreset <= 0)
        {
            mana += 1;
            Regenreset = 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
