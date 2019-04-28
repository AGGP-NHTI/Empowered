using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpawn3 : PlayerPawn
{


    public override void P3Fire1(bool value)
    {
        if (value)
        {
            controller3.RequestSpawn();

        }
    }

  
}

