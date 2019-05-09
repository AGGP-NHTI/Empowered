using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestHeal : Class
{
    public float HealAmount = 80.0f;
 
    //DragonClass dragondmg;



    void OnTriggerEnter(Collider other)
    {
        Class OtherClass = other.gameObject.GetComponentInParent<Class>();
        if (OtherClass)
        {
            OtherClass.TakeDamage(this, -HealAmount, new DamageEventInfo(typeof(AttackDamageType)), Owner);
        }
        OnDeath();
    }

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
