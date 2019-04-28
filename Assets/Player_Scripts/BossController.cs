using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossController : BossStats
{


    protected override void Start()
    {
        base.Start();
        IsHuman = true;
        LogInputStateInfo = false;


    }
    public override void P4Horizontal(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).P4Horizontal(value);
        }
    }

    public override void P4Vertical(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).P4Vertical(value);
        }
    }

    public override void P4Fire1(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P4Fire1(value);
        }
    }

    public override void P4Fire2(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P4Fire2(value);
        }
    }

    public override void P4Fire3(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P4Fire3(value);
        }
    }

    public override void P4Fire4(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P4Fire4(value);
        }
    }

    public override void Fire5(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).Fire5(value);
        }
    }

    public override void Fire6(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).Fire6(value);
        }
    }



}
