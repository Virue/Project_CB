using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody p;
    float speed = 14;
    // Start is called before the first frame update
    void Start()
    {
        p = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        p.velocity = Vector3.zero;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        p.velocity = p.velocity.normalized * speed;
    }
}
