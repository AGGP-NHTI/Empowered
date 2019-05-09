using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayers : PlayerPawn
{
    KnightClass Knight;
    MageClass Mage;
    RangerClass Ranger;
    PriestClass Priest;
    DragonClass Dragon;

    //this detects if player has fallen out of map and will kill player
    
   
    void OnTriggerEnter(Collider other)
    {
        DragonClass Dragon = other.gameObject.GetComponentInParent<DragonClass>();
        if (Dragon)
        {
            Debug.Log("Health is 0");
            Dragon.DragonHealth = 0f;
            //SceneTransition.NextPlayerArenaCount += 1;

        }
        KnightClass Knight = other.gameObject.GetComponentInParent<KnightClass>();
        if (Knight)
        {
            Knight.KnightHealth = 0f;
           // SceneTransition.NextBossArenaCount += 1;
        }
        RangerClass Ranger = other.gameObject.GetComponentInParent<RangerClass>();
        if (Ranger)
        {
            Ranger.RangerHealth = 0f;
           // SceneTransition.NextBossArenaCount += 1;
        }
        PriestClass Priest = other.gameObject.GetComponentInParent<PriestClass>();
        if (Priest)
        {
            Priest.PriestHealth = 0f;
           // SceneTransition.NextBossArenaCount += 1;
        }
        MageClass Mage = other.gameObject.GetComponentInParent<MageClass>();
        if (Mage)
        {
            Mage.MageHealth = 0f;
           // SceneTransition.NextBossArenaCount += 1;
        }
    }
}
