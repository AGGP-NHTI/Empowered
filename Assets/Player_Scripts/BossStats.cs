﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Controller4
{
    public static bool LogMissingInputDelegates = true;
    public static bool LogInputStateInfo = true;
    public static bool LogHUDUpdateError = false;

    protected delegate void InputAxis(float value);
    protected delegate void InputButton(bool value);

    protected Dictionary<string, InputAxis> AxisDelegates;
    protected Dictionary<string, InputButton> ButtonDelegates;

    protected InputPlayer IP;
    protected InputCollection IC;
    protected InputCollection ICprevious;
    public FrameworkHUD HUD;


    protected override void Start()
    {
        base.Start();
        IsHuman = true;

        IP = InputPlayer.Self;
        if (!IP)
        {
            LOG_ERROR("****PLAYER CONTROLER: No Input Poller in Scene");
            return;
        }
        AxisDelegates = new Dictionary<string, InputAxis>();
        ButtonDelegates = new Dictionary<string, InputButton>();
        IC = InputCollection.GetBlankState();
        ICprevious = InputCollection.GetBlankState();
        DefaultBinds();
    }

    protected void FixedUpdate()
    {

        GetInput();

        // Do not pass Pawn info to HUD if one or the other is missing. 
        if (!HUD && !PossesedPawn)
        {
            if (LogHUDUpdateError)
            {
                LOG_ERROR("Missing Pawn or Hud for HUD Update");
            }

            return;
        }
        UpdateHUD();
    }

    /// <summary>
    /// Override this Method to pass information from your Pawn to your HUD
    /// </summary>
    protected virtual void UpdateHUD()
    {

    }

    protected virtual void GetInput()
    {
        if (!IP)
        {
            LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): No Input Poller in Scene");
            return;
        }

        IC = InputPlayer.Self.GetPlayerInput(InputPlayerNumber);
        if (LogInputStateInfo)
        {
            LOG(IC.ToString());
        }
        ProcessInputState();
        ICprevious = IC;
    }



    protected virtual void ProcessInputState()
    {
        // Process Buttons
        foreach (KeyValuePair<string, bool> item in IC.Buttons)
        {
            if (!ButtonDelegates.ContainsKey(item.Key) && LogMissingInputDelegates)
            {
                LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): " + item.Key + " has no defined Input Delegate");
                break;
            }
            ButtonDelegates[item.Key].Invoke(item.Value);
        }

        // Process Axis
        foreach (KeyValuePair<string, float> item in IC.Axes)
        {
            if (!AxisDelegates.ContainsKey(item.Key) && LogMissingInputDelegates)
            {
                LOG_ERROR("****PLAYER CONTROLER (" + gameObject.name + "): " + item.Key + " has no defined Input Delegate");
                break;
            }
            AxisDelegates[item.Key].Invoke(item.Value);
        }
    }

    protected virtual void AddButton(string command, InputButton delegateMethod)
    {
        ButtonDelegates.Add(command, delegateMethod);
    }
    protected virtual void AddAxis(string command, InputAxis delegateMethod)
    {
        AxisDelegates.Add(command, delegateMethod);
    }

    public virtual void DefaultBinds()
    {
        AddAxis("P4Horizontal", P4Horizontal);
        AddAxis("P4Vertical", P4Vertical);
        AddButton("P4Fire1", P4Fire1);
        AddButton("P4Fire2", P4Fire2);
        AddButton("P4Fire3", P4Fire3);
        AddButton("P4Fire4", P4Fire4);
        AddButton("Fire5", Fire5);
        AddButton("Fire6", Fire6);
    }

    public virtual void P4Horizontal(float value)
    {
        if (value != 0)
        {
            LOG("Del-Horizontal (" + value + ")");
        }
    }

    public virtual void P4Vertical(float value)
    {
        if (value != 0)
        {
            LOG("Del-Vertical (" + value + ")");
        }
    }

    public virtual void P4Fire1(bool value)
    {
        if (value)
        {
            LOG("Del-Fire1");
        }
    }

    public virtual void P4Fire2(bool value)
    {
        if (value)
        {
            LOG("Del-Fire2");
        }
    }

    public virtual void P4Fire3(bool value)
    {
        if (value)
        {
            LOG("Del-Fire3");
        }
    }

    public virtual void P4Fire4(bool value)
    {
        if (value)
        {
            LOG("Del-Fire4");
        }
    }

    public virtual void Fire5(bool value)
    {
        if (value)
        {
            LOG("Del-Fire5");
        }
    }

    public virtual void Fire6(bool value)
    {
        if (value)
        {
            LOG("Del-Fire6");
        }
    }


}
