using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicExplosion : MonoBehaviour
{
    public float time;
    AudioSource explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = GetComponent<AudioSource>();
        explosion.Play();
        time = 500;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (time>=0)
        {
            time--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
