using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
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
        myControl.health = 30;
        myControl.maxHealth = 30;
        myControl.damageReduction = 0.05f;
        myControl.vulnerable = 0.05f;
        myControl.burn = 4;
        myControl.slow = 0.05f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        myControl.TakeDamage();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && myControl.health != 0)
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
