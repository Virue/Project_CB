using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class SkeletonController : MonoBehaviour
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
        AudioSource = GetComponent<AudioSource>();
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


        if (((other.tag == "PlayerWeapon") && myControl.health > 0 && playerRig.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) || ((other.tag == "FireBall" || other.tag == "IceBall" || other.tag == "Arrow") && myControl.health > 0))
        {
            AudioSource.clip = hit;
            AudioSource.Play();
            myControl.TakeDamage();
            anim.SetTrigger("Damage");

            myControl.doublestrike = Random.Range(0, 100);
            if (myControl.doublestrike < playerRig.doubleStrike)
            {
                myControl.health -= 2*playerRig.damage+playerRig.burn;
            }
            else 
            { 
                myControl.health -= playerRig.damage+playerRig.burn;
            }
            

            Debug.Log("Enemy: Damage Taken " + playerRig.damage + " from " + other.name);
            playerRig.Steal();
            if (myControl.health <= 0)
            {
                anim.SetBool("Death",true);
            }
        }
        
        if ((other.tag == "PlayerWeapon" || other.tag == "FireBall" || other.tag == "IceBall" || other.tag == "Arrow") && myControl.health <= 0)
        {
            Debug.Log("Enemy: Death Damage Taken " + playerRig.damage + " from " + other.name);
            myRig.constraints = RigidbodyConstraints.FreezeAll;
            playerRig.DeathSteal();
            anim.SetBool("Death", true);
            StartCoroutine(BodyDisposal());
        }


    }
    public IEnumerator BodyDisposal()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    void BoonApplied()
    {
        myControl.Enemy_Attack += myControl.Enemy_Attack*(playerRig.enemyDamage/100);
        myControl.health += myControl.health*(playerRig.enemyHealthBuff/100);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerRig.boonApplied)
        {
            BoonApplied();
        }
    }
}
