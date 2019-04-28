using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpawn2 : PlayerPawn
{

    

    public override void P2Fire1(bool value)
    {
        if (value)
        {
            controller2.RequestSpawn();

        }
    }

    
}

