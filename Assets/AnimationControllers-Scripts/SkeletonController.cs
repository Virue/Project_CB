using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
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
        myControl.health = 40;
        myControl.maxHealth = 40;
        myControl.Enemy_Attack = 10;
        Enemydamage = myControl.Enemy_Attack;
        myControl.damageReduction = 0.0f;
        myControl.vulnerable = 0.05f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        myControl.TakeDamage();
    }
    private void OnTriggerEnter(Collider other)
    {


        if ((other.tag == "PlayerWeapon" || other.tag == "Fireball" || other.tag == "IceBall") && myControl.health <= 0)
                {
                    myRig.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
                    anim.SetBool("Death", true);
                }
        else
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
