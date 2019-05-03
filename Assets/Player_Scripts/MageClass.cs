using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MageClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject Fire;
    public GameObject FirePoint;
    public GameObject Lightning;
    public GameObject LightningPoint;
    public GameObject ArcaneShieldPoint;

    private float CooldownTime1;
    private float CooldownTime2;
    public float cooldownPeriod1 = 19.0f;
    public float cooldownPeriod2 = 33.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
        ArcaneShieldPoint.SetActive(false);
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

        CooldownTime1 = Time.time + cooldownPeriod1;
        CooldownTime2 = Time.time + cooldownPeriod2;
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
        GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
    }

    public override void Fire2(bool value)
    {
        if(CooldownTime1 <= Time.time)
        {
            GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
        }
    }
    public override void Fire3(bool value)
    {
        if(CooldownTime2 <= Time.time)
        {
            ArcaneShieldPoint.SetActive(true);
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
    //    GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
    //}

    //public override void P1Fire2(bool value)
    //{
    //    GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
    //}
    //public override void P1Fire3(bool value)
    //{
    //    ArcaneShieldPoint.SetActive(true);
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
    //    GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
    //}

    //public override void P2Fire2(bool value)
    //{
    //    GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
    //}
    //public override void P2Fire3(bool value)
    //{
    //    ArcaneShieldPoint.SetActive(true);
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
    //    GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
    //}

    //public override void P3Fire2(bool value)
    //{
    //    GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
    //}
    //public override void P3Fire3(bool value)
    //{
    //    ArcaneShieldPoint.SetActive(true);
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
    //    GameObject FireBolt = Instantiate(Fire, FirePoint.transform.position, FirePoint.transform.rotation);
    //}

    //public override void P4Fire2(bool value)
    //{
    //    GameObject LightningBolt = Instantiate(Lightning, LightningPoint.transform.position, LightningPoint.transform.rotation);
    //}
    //public override void P4Fire3(bool value)
    //{
    //    ArcaneShieldPoint.SetActive(true);
    //}
    //public override void P4Fire4(bool value)
    //{
    //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    isGrounded = false;
    //}
}