using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpoweredInput : InputPlayer
{


    public override InputCollection GetPlayer0Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        //IC.AddAxis("Horizontal", Input.GetAxis("Horizontal"));
        //IC.AddAxis("Vertical", Input.GetAxis("Vertical"));
        IC.AddButton("Fire1", Input.GetButtonDown("Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("Fire4"));
        IC.AddButton("Fire5", Input.GetButtonDown("Fire5"));
        IC.AddButton("Fire6", Input.GetButtonDown("Fire4"));
        return IC;
    }

    public override InputCollection GetPlayer1Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        // Add P1 Tags to the Input Names and Bind them In Unity's Input
        IC.AddAxis("Horizontal", Input.GetAxis("P1Horizontal"));
        IC.AddAxis("Vertical", Input.GetAxis("P1Vertical"));
        IC.AddButton("Fire1", Input.GetButtonDown("P1Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("P1Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("P1Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("P1Fire4"));
        IC.AddButton("Fire5", Input.GetButtonDown("Fire5"));
        IC.AddButton("Fire6", Input.GetButtonDown("Fire4"));
        return IC;
    }

    public override InputCollection GetPlayer2Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("Horizontal", Input.GetAxis("P2Horizontal"));
        IC.AddAxis("Vertical", Input.GetAxis("P2Vertical"));
        IC.AddButton("Fire1", Input.GetButtonDown("P2Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("P2Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("P2Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("P2Fire4"));
        IC.AddButton("Fire5", Input.GetButtonDown("Fire5"));
        IC.AddButton("Fire6", Input.GetButtonDown("Fire4"));
        return IC;
    }

    public override InputCollection GetPlayer3Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("Horizontal", Input.GetAxis("P3Horizontal"));
        IC.AddAxis("Vertical", Input.GetAxis("P3Vertical"));
        IC.AddButton("Fire1", Input.GetButtonDown("P3Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("P3Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("P3Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("P3Fire4"));
        IC.AddButton("Fire5", Input.GetButtonDown("Fire5"));
        IC.AddButton("Fire6", Input.GetButtonDown("Fire4"));
        return IC;
    }

    public override InputCollection GetPlayer4Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("Horizontal", Input.GetAxis("P4Horizontal"));
        IC.AddAxis("Vertical", Input.GetAxis("P4Vertical"));
        IC.AddButton("Fire1", Input.GetButtonDown("P4Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("P4Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("P4Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("P4Fire4"));
        IC.AddButton("Fire5", Input.GetButtonDown("Fire5"));
        IC.AddButton("Fire6", Input.GetButtonDown("Fire4"));
        return IC;
       
    }
}
