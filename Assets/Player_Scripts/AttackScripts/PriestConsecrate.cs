using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestConsecrate : PlayerPawn
{
    
    public float lifetime = 10f;
    private void Update()
    {
        
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        KnightClass knight = other.gameObject.GetComponentInParent<KnightClass>();
        if (knight && other.gameObject.tag == "player")
        {
            InvokeRepeating("Heal1", 2, 2);
        }
        MageClass mage = other.gameObject.GetComponentInParent<MageClass>();
        if (mage && other.gameObject.tag == "player")
        {
            InvokeRepeating("Heal2", 2, 2);
        }
        PriestClass priest = other.gameObject.GetComponentInParent<PriestClass>();
        if (priest && other.gameObject.tag == "player")
        {
            InvokeRepeating("Heal3", 2, 2);
        }
        RangerClass ranger = other.gameObject.GetComponentInParent<RangerClass>();
        if (ranger && other.gameObject.tag == "player")
        {
            InvokeRepeating("Heal4", 2, 2);
        }

    }
    void Heal1()
    {
        if (KnightHealth < 400.0f)
        {
            KnightHealth += 20;
        }
        
        
    }

    void Heal2()
    {
        if (MageHealth < 345.0f)
        {
            MageHealth += 20;
        }

    }

    void Heal3()
    {
        if (PriestHealth < 345.0f)
        {
            PriestHealth += 20;
        }

    }

    void Heal4()
    {
        if (RangerHealth < 365.0f)
        {
            RangerHealth += 20;
        }
    }
}
