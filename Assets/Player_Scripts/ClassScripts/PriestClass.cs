using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PriestClass : PlayerPawn
{
    KnightClass Knight;
    MageClass Mage;
    RangerClass Ranger;

    public float PriestHealth = 380.0f;
    public float PriestMAXHealth = 380.0f;

    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject SacredGround;
    public GameObject SacredGroundPoint;
    public GameObject Holy;
    public GameObject HolyPoint;

    private float Nextfire0;
    private float Nextfire1;
    private float Nextfire2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 25.0f;
    public float cooldownPeriod2 = 45.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    
    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    protected override bool ProcessDamage(Class Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        PriestHealth -= Value;
       
        return true;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        if (PriestHealth <= 0)
        {
            controller.OnDeath();
            Destroy(gameObject);
            SceneTransition.NextBossArenaCount += 1;
        }
    }

    public override void Horizontal(float value)
    {
        if (Mathf.Abs(value) < .05)
        {
            return;
        }
        gameObject.transform.Rotate(0, (value * RotationSpeed * Time.deltaTime), 0);
    }

    public override void Vertical(float value)
    {
        if (Mathf.Abs(value) < .05)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        rb.velocity = gameObject.transform.forward * value * MovementSpeed;
    }
    public override void Fire1(bool value)
    {
        if (Time.time > Nextfire0)
        {
            Nextfire0 = Time.time + cooldownPeriod0;

            GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        if (Time.time > Nextfire1)
        {

            Nextfire1 = Time.time + cooldownPeriod1;

            if (Knight.KnightHealth >= 420.0f || Knight.KnightHealth >= 350.0f)
            {
                Knight.KnightHealth = 420.0f;
            }
            else if (Knight.KnightHealth <= 350.0f)
            {
                Knight.KnightHealth += 70.0f;
            }

            if (Ranger.RangerHealth >= 400.0f || Ranger.RangerHealth >= 330.0f)
            {
                Ranger.RangerHealth = 400.0f;
            }
            else if (Ranger.RangerHealth <= 330.0f)
            {
                Ranger.RangerHealth += 70.0f;
            }

            if (Mage.MageHealth >= 380.0f || Mage.MageHealth >= 310.0f)
            {
                Mage.MageHealth = 380.0f;
            }
            else if (Mage.MageHealth <= 310.0f)
            {
                Mage.MageHealth += 70.0f;
            }

            if (PriestHealth >= 380.0f || PriestHealth >= 310.0f)
            {
                PriestHealth = 365.0f;
            }
            else if (PriestHealth <= 310.0f)
            {
                PriestHealth += 70.0f;
            }
        }
        
    }
    public override void Fire3(bool value)
    {
        if (Time.time > Nextfire2)
        {
            Nextfire2 = Time.time + cooldownPeriod2;

            GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
        }
    }
    public override void Fire4(bool value)
    {
        if (isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        
    }

    
}