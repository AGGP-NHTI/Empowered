using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RangerClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Stab;
    public GameObject StabPoint;
    public GameObject StabPoint2;
    public GameObject Arrow;
    public GameObject BowPoint;

   
    public float ChargeStab = 5;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

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

    private void Update()
    {
        if (MageHealth <= 0)
        {
            Destroy(gameObject);
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
        rb.AddForce(transform.forward * ChargeStab);
        GameObject Eviscerate = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);

        GameObject Eviscerater = Instantiate(Stab, StabPoint2.transform.position, StabPoint2.transform.rotation);
    }

    public override void Fire2(bool value)
    {
        GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
    }
    public override void Fire3(bool value)
    {
        float Cloaktimer = 11.0f;
        if (IgnoresDamage == false && Cloaktimer == 11.0f)
        {
            IgnoresDamage = true;
            Cloaktimer -= Time.deltaTime;
            if (IgnoresDamage = true && Cloaktimer == 0.0f)
            {
                IgnoresDamage = false;
            }
        }
    }
    public override void Fire4(bool value)
    {
        rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
    //public override void P1Horizontal(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        return;
    //    }
    //    gameObject.transform.Rotate(0, (value * RotationSpeed * Time.deltaTime), 0);
    //}

    //public override void P1Vertical(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        rb.velocity = Vector3.zero;
    //        return;
    //    }
    //    rb.velocity = gameObject.transform.forward * value * MovementSpeed;
    //}
    //public override void P1Fire1(bool value)
    //{
    //    rb.AddForce(transform.forward * ChargeStab);
    //    GameObject Eviscerate = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);
    //}

    //public override void P1Fire2(bool value)
    //{
    //    GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
    //}
    //public override void P1Fire3(bool value)
    //{
    //    float Cloaktimer = 11.0f;
    //    if (IgnoresDamage == false && Cloaktimer == 11.0f)
    //    {
    //        IgnoresDamage = true;
    //        Cloaktimer -= Time.deltaTime;
    //        if (IgnoresDamage = true && Cloaktimer == 0.0f)
    //        {
    //            IgnoresDamage = false;
    //        }
    //    }
    //}
    //public override void P1Fire4(bool value)
    //{
    //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    isGrounded = false;
    //}

    //public override void P2Horizontal(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        return;
    //    }
    //    gameObject.transform.Rotate(0, (value * RotationSpeed * Time.deltaTime), 0);
    //}

    //public override void P2Vertical(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        rb.velocity = Vector3.zero;
    //        return;
    //    }
    //    rb.velocity = gameObject.transform.forward * value * MovementSpeed;
    //}
    //public override void P2Fire1(bool value)
    //{
    //    rb.AddForce(transform.forward * ChargeStab);
    //    GameObject Eviscerate = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);
    //}

    //public override void P2Fire2(bool value)
    //{
    //    GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
    //}
    //public override void P2Fire3(bool value)
    //{
    //    float Cloaktimer = 11.0f;
    //    if (IgnoresDamage == false && Cloaktimer == 11.0f)
    //    {
    //        IgnoresDamage = true;
    //        Cloaktimer -= Time.deltaTime;
    //        if (IgnoresDamage = true && Cloaktimer == 0.0f)
    //        {
    //            IgnoresDamage = false;
    //        }
    //    }
    //}
    //public override void P2Fire4(bool value)
    //{
    //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    isGrounded = false;
    //}

    //public override void P3Horizontal(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        return;
    //    }
    //    gameObject.transform.Rotate(0, (value * RotationSpeed * Time.deltaTime), 0);
    //}

    //public override void P3Vertical(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        rb.velocity = Vector3.zero;
    //        return;
    //    }
    //    rb.velocity = gameObject.transform.forward * value * MovementSpeed;
    //}
    //public override void P3Fire1(bool value)
    //{
    //    rb.AddForce(transform.forward * ChargeStab);
    //    GameObject Eviscerate = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);
    //}

    //public override void P3Fire2(bool value)
    //{
    //    GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
    //}
    //public override void P3Fire3(bool value)
    //{
    //    float Cloaktimer = 11.0f;
    //    if (IgnoresDamage == false && Cloaktimer == 11.0f)
    //    {
    //        IgnoresDamage = true;
    //        Cloaktimer -= Time.deltaTime;
    //        if (IgnoresDamage = true && Cloaktimer == 0.0f)
    //        {
    //            IgnoresDamage = false;
    //        }
    //    }
    //}
    //public override void P3Fire4(bool value)
    //{
    //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    isGrounded = false;
    //}

    //public override void P4Horizontal(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        return;
    //    }
    //    gameObject.transform.Rotate(0, (value * RotationSpeed * Time.deltaTime), 0);
    //}

    //public override void P4Vertical(float value)
    //{
    //    if (Mathf.Abs(value) < .05)
    //    {
    //        rb.velocity = Vector3.zero;
    //        return;
    //    }
    //    rb.velocity = gameObject.transform.forward * value * MovementSpeed;
    //}
    //public override void P4Fire1(bool value)
    //{
    //    rb.AddForce(transform.forward * ChargeStab);
    //    GameObject Eviscerate = Instantiate(Stab, StabPoint.transform.position, StabPoint.transform.rotation);
    //}

    //public override void P4Fire2(bool value)
    //{
    //    GameObject PiercingBolt = Instantiate(Arrow, BowPoint.transform.position, BowPoint.transform.rotation);
    //}
    //public override void P4Fire3(bool value)
    //{
    //    float Cloaktimer = 11.0f;
    //    if (IgnoresDamage == false && Cloaktimer == 11.0f)
    //    {
    //        IgnoresDamage = true;
    //        Cloaktimer -= Time.deltaTime;
    //        if (IgnoresDamage = true && Cloaktimer == 0.0f)
    //        {
    //            IgnoresDamage = false;
    //        }
    //    }
    //}
    //public override void P4Fire4(bool value)
    //{
    //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    isGrounded = false;
    //}
}