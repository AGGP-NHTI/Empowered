using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EmpController2 : PlayerStats2
{


    protected override void Start()
    {
        base.Start();
        IsHuman = true;
        LogInputStateInfo = false;


    }
    public override void P2Horizontal(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).P2Horizontal(value);
        }
    }

    public override void P2Vertical(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).P2Vertical(value);
        }
    }

    public override void P2Fire1(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P2Fire1(value);
        }
    }

    public override void P2Fire2(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P2Fire2(value);
        }
    }

    public override void P2Fire3(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P2Fire3(value);
        }
    }

    public override void P2Fire4(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P2Fire4(value);
        }
    }




}
