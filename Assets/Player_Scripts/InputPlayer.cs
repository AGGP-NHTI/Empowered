using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages player input on a per player basis. 
/// This class is used by the PlayerControler class to provide Input information. 
/// Inherit this class to define player inputs. Support for all 16 players in Unity Supported. 
/// An Example for Player 1 is provided in this class. 
/// </summary>
public class InputPlayer : PlayInfo
{

    /// <summary>
    /// Internal Static Reference 
    /// </summary>
    protected static InputPlayer _Self;

    /// <summary>
    /// Public Interface to Applications's Single Reference of this class. 
    /// </summary>
    public static InputPlayer Self
    {
        get { return _Self; }
    }

    /// <summary>
    /// Initalizes the Sington Reference. 
    /// </summary>
    private void Awake()
    {
        if (_Self)
        {
            Debug.LogError("Multiple Input Poller Classes Exist. This is a singleton object and only one should exist EVER.");
            return;
        }
        _Self = this;
    }

    public virtual InputCollection GetPlayerInput(int PlayerNumber)
    {
        if (PlayerNumber == 0) { return GetPlayer0Input(); }
        if (PlayerNumber == 1) { return GetPlayer1Input(); }
        if (PlayerNumber == 2) { return GetPlayer2Input(); }
        if (PlayerNumber == 3) { return GetPlayer3Input(); }
        if (PlayerNumber == 4) { return GetPlayer4Input(); }

        

        // Error Check... What the heck player did you give me?

        return new InputCollection();
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer0Input()
    {
        // Example Input binding. 
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddButton("Fire1", Input.GetButtonDown("Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("Fire4"));
        return IC;
        
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer1Input()
    {
        // Example Input binding. 
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("Horizontal", Input.GetAxis("Horizontal"));
        IC.AddAxis("Vertical", Input.GetAxis("Vertical"));
        IC.AddButton("Fire1", Input.GetButtonDown("Fire1"));
        IC.AddButton("Fire2", Input.GetButtonDown("Fire2"));
        IC.AddButton("Fire3", Input.GetButtonDown("Fire3"));
        IC.AddButton("Fire4", Input.GetButtonDown("Fire4"));
        return IC;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer2Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("P2Horizontal", Input.GetAxis("P2Horizontal"));
        IC.AddAxis("P2Vertical", Input.GetAxis("P2Vertical"));
        IC.AddButton("P2Fire1", Input.GetButtonDown("P2Fire1"));
        IC.AddButton("P2Fire2", Input.GetButtonDown("P2Fire2"));
        IC.AddButton("P2Fire3", Input.GetButtonDown("P2Fire3"));
        IC.AddButton("P2Fire4", Input.GetButtonDown("P2Fire4"));
        return IC;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer3Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("P3Horizontal", Input.GetAxis("P3Horizontal"));
        IC.AddAxis("P3Vertical", Input.GetAxis("P3Vertical"));
        IC.AddButton("P3Fire1", Input.GetButtonDown("P3Fire1"));
        IC.AddButton("P3Fire2", Input.GetButtonDown("P3Fire2"));
        IC.AddButton("P3Fire3", Input.GetButtonDown("P3Fire3"));
        IC.AddButton("P3Fire4", Input.GetButtonDown("P3Fire4"));
        return IC;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer4Input()
    {
        InputCollection IC = InputCollection.GetBlankState();
        IC.AddAxis("P4Horizontal", Input.GetAxis("P4Horizontal"));
        IC.AddAxis("P4Vertical", Input.GetAxis("P4Vertical"));
        IC.AddButton("P4Fire1", Input.GetButtonDown("P4Fire1"));
        IC.AddButton("P4Fire2", Input.GetButtonDown("P4Fire2"));
        IC.AddButton("P4Fire3", Input.GetButtonDown("P4Fire3"));
        IC.AddButton("P4Fire4", Input.GetButtonDown("P4Fire4"));
        IC.AddButton("Fire5", Input.GetButtonDown("Fire5"));
        IC.AddButton("Fire6", Input.GetButtonDown("Fire4"));
        return IC;
    }
}

