using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class DragonClass : PlayerPawn
{
    public float DragonHealth = 2000.00f;
    public float DragonMAXHealth = 2000.00f;

    public GameObject DragonhealthUI;

    KnightClass knight;
    MageClass mage;
    PriestClass priest;
    RangerClass ranger;
    public GameObject DamageSpawn;


    public float MovementSpeed = 45;
    public float RotationSpeed = 450;

    public GameObject Slash;
    public GameObject SlashPoint1;
    public GameObject SlashPoint2;
    public GameObject SlashPoint3;
    public GameObject SlashPoint4;
    public GameObject SlashPoint5;

    public GameObject Flame;
    public GameObject FlamePoint;

    float mouthlifetime = 1;

    public GameObject Mouth;
    public GameObject MouthPoint;

    public float ForwardBite = 5;

    private float Nextfire0;
    private float Nextfire1;
    private float Nextfire2;
    private float Nextfire3;
    private float Nextfire4;
    public float cooldownPeriod0 = 1.0f;
    public float cooldownPeriod1 = 11.0f;
    public float cooldownPeriod2 = 50.0f;
    public float cooldownPeriod3 = 60.0f;
    public float cooldownPeriod4 = 20.0f;

    public int LeechKnight;
    public int LeechMage;
    public int LeechRanger;
    public int LeechPriest;

    private float Scalestimer;
    public float Scaleslasts = 10.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;
    
    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        IgnoresDamage = false;
        jump = new Vector3(0.0f, 5.0f, 0.0f);
    }

    protected override bool ProcessDamage(Class Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        DragonHealth -= Value;
        if (DragonHealth <= 0)
        {
            SceneTransition.NextPlayerArenaCount += 1;
            controller.OnDeath();

            Destroy(gameObject);
        }
        return true;
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    private void Update()
    {
        if (DragonHealth <= 0)
        {
            Destroy(gameObject);

        }
        //Count time
        Scalestimer += Time.deltaTime;
        if (Scalestimer > Scaleslasts)
        {
            //time to remove to powerup component
            this.IgnoresDamage = false;
        }

        GameObject.FindGameObjectWithTag("DragonDeathCircle").GetComponent<Image>().fillAmount = 1 - (DragonHealth / DragonMAXHealth);

    }

    public void DragonPassive()
    {
        while (controller.isAlive == true)
        {
            InvokeRepeating("Leech1", 20, 80);
            InvokeRepeating("Leech2", 40, 80);
            InvokeRepeating("Leech3", 60, 80);
            InvokeRepeating("Leech4", 80, 80);
        }
    }
    void Leech1()
    {
        if(DragonHealth < 2595.0f)
        {
            knight.KnightHealth -= 5;
            DragonHealth += 5;
        }
        
    }

    void Leech2()
    {
        if (DragonHealth < 2595.0f)
        {
            mage.MageHealth -= 5;
            DragonHealth += 5;
        }
        
    }

    void Leech3()
    {
        if(DragonHealth < 2595.0f)
        {
            priest.PriestHealth -= 5;
            DragonHealth += 5;
        }
        
    }

    void Leech4()
    {
        if(DragonHealth < 2595.0f)
        {
            ranger.RangerHealth -= 5;
            DragonHealth += 5;
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
            Debug.Log("Fire1 DRAGO");
            Nextfire0 = Time.time + cooldownPeriod0;

            GameObject Claw1 = Instantiate(Slash, SlashPoint1.transform.position, SlashPoint1.transform.rotation);
            GameObject Claw2 = Instantiate(Slash, SlashPoint2.transform.position, SlashPoint2.transform.rotation);
            GameObject Claw3 = Instantiate(Slash, SlashPoint3.transform.position, SlashPoint3.transform.rotation);
            GameObject Claw4 = Instantiate(Slash, SlashPoint4.transform.position, SlashPoint4.transform.rotation);
            GameObject Claw5 = Instantiate(Slash, SlashPoint5.transform.position, SlashPoint5.transform.rotation);
        }
    }

    public override void Fire2(bool value)
    {
        if (Time.time > Nextfire1)
        {
            Debug.Log("Fire2 DRAGO");

            Nextfire1 = Time.time + cooldownPeriod1;

            rb.AddForce(transform.forward * ForwardBite);
            GameObject Bite = Instantiate(MouthPoint, Mouth.transform.position, Mouth.transform.rotation);
           
        }
    }
    public override void Fire3(bool value)
    {
        if (Time.time > Nextfire2)
        {
            Nextfire2 = Time.time + cooldownPeriod2;

            Scalestimer = 0;

            this.IgnoresDamage = true;

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
    public override void Fire5(bool value)
    {
        if (Time.time > Nextfire3)
        {
            Nextfire3 = Time.time + cooldownPeriod3;

            float Stop = 15.0f;
            while (Stop > 0.0f)
            {
                mage.cooldownPeriod1 = 99.9f;
                mage.cooldownPeriod2 = 99.9f;

                knight.cooldownPeriod1 = 99.9f;
                knight.cooldownPeriod2 = 99.9f;

                priest.cooldownPeriod1 = 99.9f;
                priest.cooldownPeriod2 = 99.9f;

                ranger.cooldownPeriod1 = 99.9f;
                ranger.cooldownPeriod2 = 99.9f;

                Stop -= Time.deltaTime;
            }
            

        }
    }
    public override void Fire6(bool value)
    {
        if (Time.time > Nextfire4)
        {
            Debug.Log("Firebreathhh");
            Nextfire4 = Time.time + cooldownPeriod4;

            GameObject FlameBreath = Instantiate(Flame, FlamePoint.transform.position, FlamePoint.transform.rotation);
        }
    }
}
