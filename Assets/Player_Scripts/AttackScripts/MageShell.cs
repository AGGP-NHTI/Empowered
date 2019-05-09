using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageShell : Class
{
    MageClass mage;
    public float ShieldHealth = 80;
    protected override bool ProcessDamage(Class Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        ShieldHealth -= Value;
        if (ShieldHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        return true;
    }
}
