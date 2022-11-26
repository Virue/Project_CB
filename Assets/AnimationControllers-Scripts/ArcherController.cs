using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    EnemyController myControl;
    public Animator anim;
    public Rigidbody myRig;
    public AnimationBehavior playerRig;
    public float Enemydamage;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerRig = GameObject.Find("Player").GetComponent<AnimationBehavior>();
        myControl = new EnemyController();
        myControl.health = 30;
        myControl.maxHealth = 30;
        myControl.damageReduction = 0.05f;
        myControl.Enemy_Attack = 7;
        Enemydamage = myControl.Enemy_Attack;
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
        if ((other.tag == "PlayerWeapon") && myControl.health > 0 && playerRig.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            myControl.TakeDamage();
            anim.SetTrigger("Damage");
            myControl.health -= playerRig.damage;
            Debug.Log("Archer: Damage Taken " + playerRig.damage + " from" + other.name);
        }
        if ((other.tag == "Fireball" || other.tag == "IceBall") && myControl.health > 0)
        {
            myControl.TakeDamage();
            anim.SetTrigger("Damage");
            myControl.health -= playerRig.damage;
            Debug.Log("Archer: Damage Taken " + playerRig.damage + " from" + other.name);
        }
        if ((other.tag == "PlayerWeapon" || other.tag == "Fireball" || other.tag == "IceBall") && myControl.health <= 0)
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
