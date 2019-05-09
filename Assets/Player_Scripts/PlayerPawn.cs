using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerPawn : Pawn
{

    protected float DragonHealth = 2600.00f;
    protected float KnightHealth = 420.0f;
    protected float MageHealth = 380.0f;
    protected float PriestHealth = 380.0f;
    protected float RangerHealth = 400.0f;


    protected float DragonMAXHealth = 2600.00f;
    protected float KnightMAXHealth = 420.0f;
    protected float MageMAXHealth = 380.0f;
    protected float PriestMAXHealth = 380.0f;
    protected float RangerMAXHealth = 400.0f;

    protected override bool ProcessDamage(Class Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        KnightHealth -= Value;
        if (KnightHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
        }
        MageHealth -= Value;
        if (MageHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
            
        }
        PriestHealth -= Value;
        if (PriestHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
        }
        RangerHealth -= Value;
        if (RangerHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
        }
        DragonHealth -= Value;
        if (DragonHealth <= 0)
        {
            SceneTransition.NextPlayerArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
            
        }
        return true;
    }
    public virtual void Start()
    {
        IgnoresDamage = false;  
    }

    public virtual void Horizontal(float value)
    {

    }

    public virtual void Vertical(float value)
    {

    }

    public virtual void Fire1(bool value)
    {

    }

    public virtual void Fire2(bool value)
    {

    }

    public virtual void Fire3(bool value)
    {

    }

    public virtual void Fire4(bool value)
    {

    }

    public virtual void Fire5(bool value)
    {

    }

    public virtual void Fire6(bool value)
    {

    }

    //public virtual void P1Horizontal(float value)
    //{

    //}

    //public virtual void P1Vertical(float value)
    //{

    //}

    //public virtual void P1Fire1(bool value)
    //{

    //}

    //public virtual void P1Fire2(bool value)
    //{

    //}

    //public virtual void P1Fire3(bool value)
    //{

    //}

    //public virtual void P1Fire4(bool value)
    //{

    //}

    //public virtual void P2Horizontal(float value)
    //{

    //}

    //public virtual void P2Vertical(float value)
    //{

    //}

    //public virtual void P2Fire1(bool value)
    //{

    //}

    //public virtual void P2Fire2(bool value)
    //{

    //}

    //public virtual void P2Fire3(bool value)
    //{

    //}

    //public virtual void P2Fire4(bool value)
    //{

    //}

    //public virtual void P3Horizontal(float value)
    //{

    //}

    //public virtual void P3Vertical(float value)
    //{

    //}

    //public virtual void P3Fire1(bool value)
    //{

    //}

    //public virtual void P3Fire2(bool value)
    //{

    //}

    //public virtual void P3Fire3(bool value)
    //{

    //}

    //public virtual void P3Fire4(bool value)
    //{

    //}

    //public virtual void P4Horizontal(float value)
    //{

    //}

    //public virtual void P4Vertical(float value)
    //{

    //}

    //public virtual void P4Fire1(bool value)
    //{

    //}

    //public virtual void P4Fire2(bool value)
    //{

    //}

    //public virtual void P4Fire3(bool value)
    //{

    //}

    //public virtual void P4Fire4(bool value)
    //{

    //}


}
