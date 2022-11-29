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
    AudioSource AudioSource;
    public AudioClip hit;
    // Start is called before the first frame update
    void Start()
    {
        myRig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerRig = GameObject.Find("Player").GetComponent<AnimationBehavior>();
        AudioSource = GetComponent<AudioSource>();
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
        if (((other.tag == "PlayerWeapon") && myControl.health > 0 && playerRig.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) || ((other.tag == "FireBall" || other.tag == "IceBall") && myControl.health > 0))
        {
            AudioSource.clip = hit;
            AudioSource.Play();
            myControl.TakeDamage();
            anim.SetTrigger("Damage");
            myControl.health -= playerRig.damage;
            Debug.Log("Archer: Damage Taken " + playerRig.damage + " from " + other.name);
        }
        if ((other.tag == "PlayerWeapon" || other.tag == "FireBall" || other.tag == "IceBall") && myControl.health <= 0)
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
