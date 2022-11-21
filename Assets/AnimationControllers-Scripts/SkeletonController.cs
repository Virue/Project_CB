using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    EnemyController myControl;
    Animator anim;
    public Rigidbody myRig;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        myControl = new EnemyController();
        myControl.health = 40;
        myControl.maxHealth = 40;
        myControl.damageReduction = 0.0f;
        myControl.vulnerable = 0.05f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        myControl.TakeDamage();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && myControl.health!=0)
        {
            myControl.TakeDamage();
            anim.SetTrigger("Damage");
            myControl.health -= 5;
        }
        if (other.tag != "Player" && myControl.health == 0)
        {
            myRig.constraints = RigidbodyConstraints.FreezeAll;
            anim.SetBool("Death", true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
