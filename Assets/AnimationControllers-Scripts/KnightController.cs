using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
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
        myControl.health = 80;
        myControl.maxHealth = 80;
        myControl.Enemy_Attack = 20;
        Enemydamage = myControl.Enemy_Attack;
        myControl.damageReduction = 0.20f;
        myControl.vulnerable = 0.10f;
        myControl.burn =0;
        myControl.slow=0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        myControl.TakeDamage();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "PlayerWeapon" || other.tag == "Fireball" || other.tag == "IceBall") && myControl.health > 0)
        {
            myControl.TakeDamage();
            anim.SetTrigger("Damage");
            myControl.health -= playerRig.damage;
            Debug.Log("Damage Taken " + playerRig.damage);
        }

        if ((other.tag == "PlayerWeapon" || other.tag == "Fireball" || other.tag == "IceBall") && myControl.health <= 0)
        {
            myRig.constraints = RigidbodyConstraints.FreezeAll;
            myControl.health -= playerRig.damage;
            Debug.Log("Damage Taken " + playerRig.damage);
            anim.SetBool("Death", true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
