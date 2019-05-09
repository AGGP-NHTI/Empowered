using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpawn : PlayerPawn
{



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    new private void Start()
    {
        //controller.RequestSpawn();

    }

    public override void Fire1(bool value)
    {
        if (value && controller.isAlive)
        {
            controller.RequestSpawn();
        }
    }

}

