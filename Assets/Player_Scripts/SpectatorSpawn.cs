﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpawn : PlayerPawn
{



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public override void Fire1(bool value)
    {
        if (value)
        {
            controller.RequestSpawn();

        }
    }
    
}

