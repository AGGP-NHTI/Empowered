﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller2 : PlayInfo
{


    public bool IsHuman = false;
    public bool UseSpawnSystem = true;

    public static bool LogPossessionFailures = true;
    public bool StartWithSpectator = true;
    public static GameObject SpawnPreFab2;
    public GameObject SpectatorPreFab;
    protected GameObject SpectatorActor;
    //protected Pawn SpeactatorPawn; 

    /// <summary>
    /// Player Number for Grabbing Input
    /// </summary>
    public int InputPlayerNumber = 0;

    /// <summary>
    /// Player Number in the game
    /// </summary>
    public int PlayerNumber = 0;

    protected Pawn PossesedPawn;

    protected virtual void Start()
    {
        if (!UseSpawnSystem)
        {
            return;
        }

        // Create Spectator Prefab
        if (SpectatorPreFab)
        {
            SpectatorActor = Factory2(SpectatorPreFab, Vector3.zero, new Quaternion(), this);
        }

        if (StartWithSpectator)
        {
            // Grab the Spectator Prefab
            RequestSpectate();
        }
        else
        {
            //  Spawn and new Active Game Object and grab it. 
            RequestSpawn();
        }
    }

    public Pawn GetPossesedPawn()
    {
        return PossesedPawn;
    }

    public virtual bool PossesPawn(Pawn p)
    {

        if (!(p.Possesed(this)))
        {
            LOG_ERROR("Controler - Possession Failure");
            return false;
        }

        // If we have a Possessed Pawn already, Call Unpossess on it. 
        if (PossesedPawn)
        {
            PossesedPawn.BecomeUnPossesed();
        }

        PossesedPawn = p;
        return true;
    }

    /// <summary>
    /// PossesPawn version taking GameObject with Pawn Script attached to it. 
    /// </summary>
    /// <param name="PawnGameObject">Game Object with Pawn Script Attached to it</param>
    /// <returns></returns>
    public virtual bool PossesPawn(GameObject PawnGameObject)
    {
        Pawn p = PawnGameObject.GetComponent<Pawn>();
        if (!p)
        {
            LOG_ERROR("GameObject " + PawnGameObject.name + " is not a pawn.");
            return false;
        }
        return PossesPawn(p);
    }

    public virtual bool UnPossesPawn(Pawn p)
    {
        p.BecomeUnPossesed();

        PossesedPawn = null;
        return true;
    }

    public GameObject RequestSpawn()
    {
        if (!SpawnPreFab2)
        {
            LOG_ERROR("No Spawn Prefab Set for Spawning");
            return null;
        }
        return SpawnSystem.Self.RequestSpawn(this, SpawnPreFab2);
    }

    public GameObject RequestSpawnAt(Transform SpawnPoint)
    {
        if (!SpawnPreFab2)
        {
            LOG_ERROR("No Spawn Prefab Set for Spawning");
            return null;
        }
        GameObject Pawn = Factory2(SpawnPreFab2, SpawnPoint.position, SpawnPoint.rotation, this);
        PossesPawn(Pawn);
        return Pawn;
    }

    public bool RequestSpectate()
    {
        if (!SpectatorActor)
        {
            LOG_ERROR("*** No Spectator Actor Assigned");
            return false;
        }
        PossesPawn(SpectatorActor);
        return true;
    }
    public virtual void OnDeath()
    {

    }

}
