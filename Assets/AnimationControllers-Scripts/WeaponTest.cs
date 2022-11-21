using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    public Collider s;
    // Start is called before the first frame update
    void Start()
    {
        s.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            Debug.Log(other.tag + " Hit");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
