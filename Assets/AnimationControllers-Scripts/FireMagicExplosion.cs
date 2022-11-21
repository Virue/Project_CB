using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMagicExplosion : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
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
