using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpawn4 : PlayerPawn
{

    public override void P4Fire1(bool value)
    {
        if (value)
        {
            controller4.RequestSpawn();

        }
    }
}

