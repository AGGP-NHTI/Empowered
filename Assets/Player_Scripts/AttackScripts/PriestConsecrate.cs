using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestConsecrate : PlayerPawn
{
    KnightClass Knight;
    MageClass Mage;
    RangerClass Ranger;
    PriestClass Priest;
    DragonClass Dragon;

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
        if (Knight.KnightHealth < 400.0f)
        {
            Knight.KnightHealth += 20;
        }
        
        
    }

    void Heal2()
    {
        if (Mage.MageHealth < 360.0f)
        {
            Mage.MageHealth += 20;
        }

    }

    void Heal3()
    {
        if (Priest.PriestHealth < 360.0f)
        {
            Priest.PriestHealth += 20;
        }

    }

    void Heal4()
    {
        if (Ranger.RangerHealth < 380.0f)
        {
            Ranger.RangerHealth += 20;
        }
    }
}
