using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScript : MonoBehaviour
{
    Vector3 goal1;
    Vector3 goal2;
    Vector3 player;
    Animator anim;
    public float detectionRadius;
    public float reset;
    UnityEngine.AI.NavMeshAgent myNav = null;
    public Rigidbody myRig;
    public Rigidbody playerRig;
    public AudioClip swing;
    AudioSource Source;
    public int goal = 0;
    public string goalOne;
    public string goalTwo;
    Vector3 distancetoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        myNav = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        myRig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Source = GetComponent<AudioSource>();
        playerRig = GameObject.Find("Player").GetComponent<Rigidbody>();
        goal1 = GameObject.Find(goalOne).transform.position;
        goal2 = GameObject.Find(goalTwo).transform.position;
        player = GameObject.Find("Player").transform.position;
        myNav.destination = goal1;
        myNav.Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            myRig.constraints = RigidbodyConstraints.FreezeAll;
            goal1 = myRig.position;
            myNav.destination = goal1;
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                myRig.constraints = RigidbodyConstraints.FreezeAll;
            }
            else
            {
                myRig.constraints = RigidbodyConstraints.None;
                myRig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            }
            reset -= Time.deltaTime;
            anim.SetFloat("Speed", myRig.velocity.magnitude);
            if (goal > 1)
            {
                goal = 0;
                myNav.destination = goal1;
            }
            distancetoPlayer = new Vector3(myRig.position.x - playerRig.position.x, 0, myRig.position.z - playerRig.position.z);

            if (distancetoPlayer.magnitude <= detectionRadius && !anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {

                player = GameObject.Find("Player").transform.position;
                myNav.destination = player;
                if (myNav.remainingDistance <= 2.0f)
                {
                    if (reset <= 0)
                    {
                        anim.SetTrigger("Attack");
                        Source.clip = swing;
                        Source.Play();
                        reset = 2;
                    }

                }
            }
            else
            if (distancetoPlayer.magnitude > detectionRadius)
            {
                if (myNav.remainingDistance == 0 || myNav.remainingDistance < 0.5)
                {
                    if (goal == 0)
                    {
                        goal++;
                        myNav.destination = goal2;
                        myNav.Resume();
                    }
                    else
                    if (goal == 1)
                    {
                        goal = 0;
                        myNav.destination = goal1;
                        myNav.Resume();
                    }
                }
            }
        }
    }


}
