using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretClass : MonoBehaviour
{
    public GameObject focus = null;
    Vector3 player;
    public bool dead;
    public GameObject myPrefab;
    Animator anim;
    public float reset;
    UnityEngine.AI.NavMeshAgent myNav = null;
    LookAtMe lookAt;
    public Rigidbody myRig;
    public Rigidbody playerRig;
    public float right=5.0f;
    Vector3 distancetoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myNav = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        myRig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        lookAt = GetComponent<LookAtMe>();
        playerRig = GameObject.Find("Player").GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform.position;
        myNav.destination = player;
        myNav.Resume();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "player" || other.tag != "Enemy")
        {
            anim.SetBool("Damage", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Damage", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            dead = true;
        }
        myRig.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        reset -= Time.deltaTime;
        anim.SetFloat("Speed", myRig.velocity.magnitude);
        distancetoPlayer = new Vector3(myRig.position.x - playerRig.position.x, 0, myRig.position.z - playerRig.position.z);
        if (dead != true)
        {
            if (focus != null)
            {
                this.transform.LookAt(focus.transform);
            }
            if (distancetoPlayer.magnitude <= 10f)
            {

                player = GameObject.Find("Player").transform.position;
                myNav.destination = player;
                if (distancetoPlayer.magnitude <= 20.0f)
                {
                    if (reset <= 0)
                    {
                        anim.SetTrigger("Attack");
                        GameObject p = Instantiate(myPrefab, this.transform.localPosition, transform.rotation);
                        Rigidbody pRig = p.GetComponent<Rigidbody>();
                        pRig.position = myRig.transform.position + myRig.transform.right * right + myRig.transform.up * 1.2f + myRig.transform.forward * 1.5f;
                        p.GetComponent<Rigidbody>().velocity = myRig.transform.forward;
                        reset = 15;
                    }

                }
            }
        }
        else 
        {
            
        }
        
    }
}
