using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorSpawn : PlayerPawn
{

    public override void Fire1(bool value)
    {
        if (value)
        {
            controller.RequestSpawn();

        }
    }
    //public override void P2Fire1(bool value)
    //{
    //    if (value)
    //    {
    //        controller.RequestSpawn();

    //    }
    //}
    //public override void P3Fire1(bool value)
    //{
    //    if (value)
    //    {
    //        controller.RequestSpawn();

    //    }
    //}
    //public override void P4Fire1(bool value)
    //{
    //    if (value)
    //    {
    //        controller.RequestSpawn();

    //    }
    //}
}

