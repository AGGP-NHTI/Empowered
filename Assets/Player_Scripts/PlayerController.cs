using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public virtual void Player_Base_Stats()
    {
        float BaseHP = 500.0f;
        float BaseSpeed = 10f;
        float BaseAttackRange = 5f;
        float BaseArmor = 90f;
        float BaseAttackSpeed = 15f;
        //float BaseMana = 100f; We may want to add a base mana bar for spell casters for flavor and more elegant gameplay
        //float BaseEnergy = 100f; Same for melee and physical classes, it would just look neater, but we can talk before implimentation  
    }
    public virtual void SpamAttack()
    {

    }
    public virtual void LargeOnCooldownMove()
    {

    }
    public virtual void EvasionOrDefensiveMove()
    {

    }
}
