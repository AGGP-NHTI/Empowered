using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Class
{
    public float PlayerdamageAmount = 35.0f;
    public float BossdamageAmount = 100.0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Class OtherClass = other.gameObject.GetComponentInParent<Class>();
        if(OtherClass && other.gameObject.tag == "Boss")
        {
            OtherClass.TakeDamage(this, BossdamageAmount, new DamageEventInfo(typeof(AttackDamageType)), Owner);
        }
        if (OtherClass && other.gameObject.tag == "Player")
        {
            OtherClass.TakeDamage(this, BossdamageAmount, new DamageEventInfo(typeof(AttackDamageType)), Owner);
        }
    }
  
    
        

        
  
}
