using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagic : MonoBehaviour
{
    public Rigidbody p;
    public GameObject explosion;
    float speed=10;
    AudioSource magic;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Rigidbody>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject g = Instantiate(explosion,p.transform.position,transform.rotation);
        Rigidbody pRig = g.GetComponent<Rigidbody>();
        pRig.position = p.transform.position-p.transform.right*5.0f;
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject g = Instantiate(explosion, p.transform.position, transform.rotation);
        Rigidbody pRig = g.GetComponent<Rigidbody>();
        pRig.position = p.transform.position - p.transform.right * 5.0f;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
        p.velocity = p.velocity.normalized * speed;
        
    }
}
