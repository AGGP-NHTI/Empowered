using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class KnightClass : PlayerPawn
{
    PriestClass priest;
    public float KnightHealth = 420.0f;
    public float KnightMAXHealth = 420.0f;

    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Slash;
    public GameObject SlashPoint;
    public GameObject AirShield;
    public GameObject AirShieldPoint;
    public GameObject BashRushPoint;
    public float ChargeAttack = 40;

    private float Nextfire0;
    private float Nextfire1;
    private float Nextfire2;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 13.0f;
    public float cooldownPeriod2 = 40.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;
    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        BashRushPoint.SetActive(false);
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    private void Update()
    {
       

        if (KnightHealth <= 0)
        {
            SceneTransition.NextBossArenaCount += 1;
            Destroy(gameObject);
            controller.OnDeath();
        }

        GameObject.FindGameObjectWithTag("KnightDeathCircle").GetComponent<Image>().fillAmount = 1 - (KnightHealth / KnightMAXHealth);

    }
    protected override bool ProcessDamage(Class Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        KnightHealth -= Value;
        return true;
    }
void OnCollisionStay()
    {
        isGrounded = true;
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

            GameObject SwordSlash = Instantiate(Slash, SlashPoint.transform.position, SlashPoint.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        if (Time.time > Nextfire1)
        {
            Nextfire1 = Time.time + cooldownPeriod1;

            BashRushPoint.SetActive(true);

            this.rb.AddForce(transform.forward * ChargeAttack);
        }
        
    }
    public override void Fire3(bool value)
    {
        if (Time.time > Nextfire2)
        {
            Nextfire2 = Time.time + cooldownPeriod2;

            GameObject AirShieldWall = Instantiate(AirShield, AirShieldPoint.transform.position, AirShieldPoint.transform.rotation);
        }
    }
    //public override void Fire4(bool value)
    //{
    //    if (isGrounded)
    //    {
    //        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //        isGrounded = false;
    //    }      
    //}
}