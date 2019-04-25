using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EmpController : PlayerStats
{
    
    
    protected override void Start()
    {
        base.Start();
        IsHuman = true;
        LogInputStateInfo = false;


    }
    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).Horizontal(value);
        }
    }

    public override void Vertical(float value)
    {
        if (value != 0)
        {
            ((PlayerPawn)PossesedPawn).Vertical(value);
        }
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).Fire1(value);
        }
    }

    public override void Fire2(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).Fire2(value);
        }
    }

    public override void Fire3(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).Fire3(value);
        }
    }

    public override void Fire4(bool value)
    {
        if (value)
        {
            ((PlayerPawn)PossesedPawn).Fire4(value);
        }
    }

    


}
