﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerPawn : Pawn
{
    protected float DragonHealth = 2559.00f;
    protected float KnightHealth = 420.0f;
    protected float MageHealth = 365.0f;
    protected float PriestHealth = 365.0f;
    protected float RangerHealth = 385.0f;
    
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
        if (RangerHealth <= 0)
        {
            SceneTransition.NextPlayerArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
            
        }
        return true;
    }
    public void Start()
    {
        {
            IgnoresDamage = false;
        }
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
}
