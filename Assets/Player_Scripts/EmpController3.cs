using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EmpController3 : PlayerStats3
{


    protected override void Start()
    {
        base.Start();
        IsHuman = true;
        LogInputStateInfo = false;


    }
    public override void P3Horizontal(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).P3Horizontal(value);
        }
    }

    public override void P3Vertical(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).P3Vertical(value);
        }
    }

    public override void P3Fire1(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P3Fire1(value);
        }
    }

    public override void P3Fire2(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P3Fire2(value);
        }
    }

    public override void P3Fire3(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P3Fire3(value);
        }
    }

    public override void P3Fire4(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).P3Fire4(value);
        }
    }




}
