using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class RangerClass : PlayerPawn
{
    public float RangerHealth = 400.0f;
    public float RangerMAXHealth = 400.0f;

    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Stab;
    public GameObject StabPoint;
    public GameObject StabPoint2;
    public GameObject Arrow;
    public GameObject BowPoint;
    public float ChargeStab = 5;

    private float Nextfire0;
    private float Nextfire1;
    private float Nextfire2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 17.0f;
    public float cooldownPeriod2 = 37.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    private float Cloaktimer;
    public float Cloaklasts = 3.0f;

    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        IgnoresDamage = false;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    protected override bool ProcessDamage(Class Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        RangerHealth -= Value;
        return true;
    }

    private void Update()
    {
        if (RangerHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
        }

        //Count time
        Cloaktimer += Time.deltaTime;
        if (Cloaktimer > Cloaklasts)
        {
            //time to remove to powerup component
            this.IgnoresDamage = false;
        }

        GameObject.FindGameObjectWithTag("RangerDeathCircle").GetComponent<Image>().fillAmount = 1 - (RangerHealth / RangerMAXHealth);

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

            rb.AddForce(transform.forward * ChargeStab);
            GameObject Eviscerate1 = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);
            GameObject Eviscerate2 = Instantiate(Stab, StabPoint2.transform.position, StabPoint2.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {

        if (Time.time > Nextfire1)
        {
            Nextfire1 = Time.time + cooldownPeriod1;

            GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
        }
    }
    public override void Fire3(bool value)
    {
        if (Time.time > Nextfire2)
        {

            Cloaktimer = 0;

            Nextfire2 = Time.time + cooldownPeriod2;

            this.IgnoresDamage = true;


            /*
            float Cloaktimer = 14.0f;

            if (this.IgnoresDamage == false && Cloaktimer == 14.0f)
            {
                this.IgnoresDamage = true;
                Cloaktimer -= Time.deltaTime;
                if (this.IgnoresDamage = true && Cloaktimer == 0.0f)
                {
                    this.IgnoresDamage = false;
                }
            }
            */
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