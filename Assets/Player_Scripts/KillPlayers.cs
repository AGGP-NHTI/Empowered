using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayers : PlayerPawn
{
    //this detects if player has fallen out of map and will kill player
    private void Update()// need this to detect health and update!
    {    
        if (KnightHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
        }
        if (MageHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
        }
      
        if (PriestHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);          
        }

        if (RangerHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);           
        }
        if (DragonHealth <= 0)
        {
            Debug.Log("Hi");
            SceneTransition.NextPlayerArenaCount += 1;
            Destroy(gameObject);
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        DragonClass Dragon = other.gameObject.GetComponentInParent<DragonClass>();
        if (Dragon)
        {
            Debug.Log("Health is 0");
            DragonHealth = 0f;
        }
        KnightClass Knight = other.gameObject.GetComponentInParent<KnightClass>();
        if (Knight)
        {
            KnightHealth = 0f;
        }
        RangerClass ranger = other.gameObject.GetComponentInParent<RangerClass>();
        if (ranger)
        {
            RangerHealth = 0f;
        }
        PriestClass Priest = other.gameObject.GetComponentInParent<PriestClass>();
        if (Priest)
        {
            PriestHealth = 0f;
        }
        MageClass Mage = other.gameObject.GetComponentInParent<MageClass>();
        if (Mage)
        {
            MageHealth = 0f;
        }
    }
}
