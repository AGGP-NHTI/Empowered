using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EmpController : PlayerController
{
    
    
    protected override void Start()
    {
        base.Start();
        IsHuman = true;
        LogInputStateInfo = false;


    }

    public void SpawnUI(Vector3 UILocation, Canvas levelCanvas)
    {
        Instantiate(UIPreFab, UILocation, Quaternion.Euler(0, 0, 0), levelCanvas.transform);
        // Spawn UI at location given as paramerter
        // Spawn Prefab was assgined on select
        // We don't need to rotate it. 


        // After spawn Grab the UI Prefab script
        // and store it locally 

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
