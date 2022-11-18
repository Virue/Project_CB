using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorScript : MonoBehaviour
{
    Vector3 goal1;
    Vector3 goal2;
    Vector3 player;
    Animator anim;
    UnityEngine.AI.NavMeshAgent myNav = null;
    public Rigidbody myRig;
    public Rigidbody playerRig;
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
        anim.SetFloat("Speed", myRig.velocity.magnitude);
        if (goal > 1)
        {
            goal = 0;
            myNav.destination = goal1;
        }
        distancetoPlayer = new Vector3(myRig.position.x - playerRig.position.x, 0, myRig.position.z - playerRig.position.z);
        
        if (distancetoPlayer.magnitude <= 5f)
        {

            player = GameObject.Find("Player").transform.position;
            myNav.destination = player;

        }
        else
        if (distancetoPlayer.magnitude > 5f)
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
                    goal=0;
                    myNav.destination = goal1;
                    myNav.Resume();
                }
            }
        }
    }


}
