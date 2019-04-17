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
        if (PlayerNumber == 0) { return GetPlayer1Input(); }
        if (PlayerNumber == 1) { return GetPlayer2Input(); }
        if (PlayerNumber == 2) { return GetPlayer3Input(); }
        if (PlayerNumber == 3) { return GetPlayer4Input(); }

        

        // Error Check... What the heck player did you give me?

        return new InputCollection();
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer1Input()
    {
        // Example Input binding. 
        InputCollection IC = InputCollection.GetBlankState();
       
        return IC;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer2Input()
    {
        InputCollection IC = InputCollection.GetBlankState();

        return IC;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer3Input()
    {
        InputCollection IC = InputCollection.GetBlankState();

        return IC;
    }

    /// <summary>
    /// Input Setup Method for Specific Player. Add Implementation in Inherited Class for Application
    /// </summary>
    /// <returns>InputState for Requested Player</returns>
    public virtual InputCollection GetPlayer4Input()
    {
        InputCollection IC = InputCollection.GetBlankState();

        return IC;
    }
}

