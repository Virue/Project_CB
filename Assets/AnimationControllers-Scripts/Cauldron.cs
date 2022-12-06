using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{

    GameObject player;
    Transform mytransform;
    AnimationBehavior playerControl;
    bool heal = true;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<AnimationBehavior>();
    }
    public IEnumerator HealReset()
    {
        yield return new WaitForSeconds(2.0f);
        heal=true;
    }
    // Update is called once per frame
    void Update()
    {
        if ((mytransform.position-player.transform.position).magnitude <= 2.0f && heal == true) 
        {
            playerControl.heal(health);
            heal = false;
            StartCoroutine(HealReset());
        } 
    }
}
