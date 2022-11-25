using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
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
        myControl.health = 60;
        myControl.maxHealth = 60;
        myControl.Enemy_Attack = 18;
        myControl.damageReduction = 0.05f;
        Enemydamage = myControl.Enemy_Attack;
        myControl.vulnerable = 0.15f;
        myControl.burn = 5;
        myControl.slow = 0.1f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        myControl.TakeDamage();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "PlayerWeapon" || other.tag == "Fireball" || other.tag == "IceBall") && myControl.health <= 0)
        {
            myRig.constraints = RigidbodyConstraints.FreezeAll;
            anim.SetBool("Death", true);
        }
        if ((other.tag == "PlayerWeapon" || other.tag == "Fireball" || other.tag == "IceBall") && myControl.health > 0)
        {
            myControl.TakeDamage();
            anim.SetTrigger("Damage");
            myControl.health -= playerRig.damage;
            Debug.Log("Damage Taken " + playerRig.damage);
        }
        
        

    }
    // Update is called once per frame
    void Update()
    {

    }
}
