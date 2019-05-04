using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightShieldWall : Class
{
    

    public float lifetime = 10f;
    Rigidbody rb;

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();

    }

    private void Update()
    {
        Destroy(gameObject, lifetime);
    }

    
}
