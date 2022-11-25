using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Stats
{
    Rigidbody myRig;
    Animator anim;
    public float Enemy_Attack;
    public float damageReduction;
    public float vulnerable;
    public float burn=0;
    public float slow=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TakeDamage()
    {
        Debug.Log("Take damage called EnemyController");
    }
    public void Die()
    { 
        Debug.Log("Die called");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
