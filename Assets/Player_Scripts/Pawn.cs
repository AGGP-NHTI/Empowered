using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pawn, Can be Possesed by Controller.
/// BY DESIGN, this implementation does not have any default Input methods.
/// Inherit from Pawn into your own class to implement those functions. 
/// </summary>
public class Pawn : Class
{

    public bool IsSpectator = true;

    /// <summary>
    /// Controler who is in charge of this object. 
    /// </summary>
    protected Controller _controller;
    protected Controller2 _controller2;
    protected Controller3 _controller3;
    protected Controller4 _controller4;
    /// <summary>
    /// READY ONLY, access to the Controller (Player or AI) for this pawn
    /// </summary>
    public Controller controller
    {
        get { return _controller; }
    }

    public Controller2 controller2
    {
        get { return _controller2; }
    }

    public Controller3 controller3
    {
        get { return _controller3; }
    }

    public Controller4 controller4
    {
        get { return _controller4; }
    }
    /// <summary>
    /// Method access to the Controller (Player or AI) for this pawn
    /// </summary>
    public Controller GetController()
    {
        return _controller;
    }

    public Controller2 GetController2()
    {
        return _controller2;
    }

    public Controller3 GetController3()
    {
        return _controller3;
    }

    public Controller4 GetController4()
    {
        return _controller4;
    }
    /// <summary>
    /// Sets controller and Owner Variables 
    /// </summary>
    /// <param name="c">Controller to take control of this pawn</param>
    /// <returns></returns>
    public bool Possesed(Controller c)
    {
        _controller = c;
        Owner = c;
        OnPossession();
        return true;
    }

    public bool Possesed(Controller2 c)
    {
        _controller2 = c;
        Owner2 = c;
        OnPossession();
        return true;
    }

    public bool Possesed(Controller3 c)
    {
        _controller3 = c;
        Owner3 = c;
        OnPossession();
        return true;
    }

    public bool Possesed(Controller4 c)
    {
        _controller4 = c;
        Owner4 = c;
        OnPossession();
        return true;
    }
    /// <summary>
    /// Pawn is no longer possessed. Owner is Unchanged. 
    /// Calls OnUnPossession  
    /// </summary>
    public void BecomeUnPossesed()
    {
        OnUnPossession();
        _controller = null;
    }

    public void BecomeUnPossesed2()
    {
        OnUnPossession();
        _controller2 = null;
    }

    public void BecomeUnPossesed3()
    {
        OnUnPossession();
        _controller3 = null;
    }

    public void BecomeUnPossesed4()
    {
        OnUnPossession();
        _controller4 = null;
    }


    /// <summary>
    /// Pawn is no longer possessed. This version resets Owner to null as well.
    /// Calls OnUnPossession
    /// </summary>
    /// <returns>Previous Controller</returns>
    public Controller ForceUnPosses()
    {
        OnUnPossession();
        Controller c = _controller;
        _controller = null;
        Owner = null;

        return c;
    }
    public Controller2 ForceUnPosses2()
    {
        OnUnPossession();
        Controller2 c = _controller2;
        _controller2 = null;
        Owner = null;

        return c;
    }

    public Controller3 ForceUnPosses3()
    {
        OnUnPossession();
        Controller3 c = _controller3;
        _controller3 = null;
        Owner = null;

        return c;
    }

    public Controller4 ForceUnPosses4()
    {
        OnUnPossession();
        Controller4 c = _controller4;
        _controller4 = null;
        Owner = null;

        return c;
    }


    public virtual void OnPossession()
    {

    }

    public virtual void OnUnPossession()
    {

    }
}
