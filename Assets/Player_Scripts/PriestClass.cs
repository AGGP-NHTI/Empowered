using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PriestClass : PlayerPawn
{
    public float MovementSpeed = 14;
    public float RotationSpeed = 280;

    public GameObject SacredGround;
    public GameObject SacredGroundPoint;
    public GameObject Holy;
    public GameObject HolyPoint;
  

    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;

    new void Start()
    {
        rb = GetComponent<Rigidbody>();
       
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Update()
    {
        if (PriestHealth <= 0)
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
        GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
    }

    public override void Fire2(bool value)
    {

        if (KnightHealth >= 420.0f || KnightHealth >= 350.0f)
        {
            KnightHealth = 420.0f;
        }
        else if (KnightHealth <= 350.0f)
        {
            KnightHealth += 70.0f;
        }

        if (RangerHealth >= 385.0f || KnightHealth >= 315.0f)
        {
            RangerHealth = 385.0f;
        }
        else if (RangerHealth <= 315.0f)
        {
            RangerHealth += 70.0f;
        }

        if (MageHealth >= 365.0f || MageHealth >= 295.0f)
        {
            MageHealth = 365.0f;
        }
        else if (MageHealth <= 295.0f)
        {
            MageHealth += 70.0f;
        }

        if (PriestHealth >= 365.0f || PriestHealth >= 295.0f)
        {
            PriestHealth = 365.0f;
        }
        else if (PriestHealth <= 295.0f)
        {
            PriestHealth += 70.0f;
        }
    }
    public override void Fire3(bool value)
    {
        GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
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
    //    GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
    //}

    //public override void P1Fire2(bool value)
    //{

    //    if (KnightHealth >= 420.0f || KnightHealth >= 350.0f)
    //    {
    //        KnightHealth = 420.0f;
    //    }
    //    else if (KnightHealth <= 350.0f)
    //    {
    //        KnightHealth += 70.0f;
    //    }

    //    if (RangerHealth >= 385.0f || KnightHealth >= 315.0f)
    //    {
    //        RangerHealth = 385.0f;
    //    }
    //    else if (RangerHealth <= 315.0f)
    //    {
    //        RangerHealth += 70.0f;
    //    }

    //    if (MageHealth >= 365.0f || MageHealth >= 295.0f)
    //    {
    //        MageHealth = 365.0f;
    //    }
    //    else if (MageHealth <= 295.0f)
    //    {
    //        MageHealth += 70.0f;
    //    }

    //    if (PriestHealth >= 365.0f || PriestHealth >= 295.0f)
    //    {
    //        PriestHealth = 365.0f;
    //    }
    //    else if (PriestHealth <= 295.0f)
    //    {
    //        PriestHealth += 70.0f;
    //    }    
    //}
    //public override void P1Fire3(bool value)
    //{
    //    GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
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
    //    GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
    //}

    //public override void P2Fire2(bool value)
    //{

    //    if (KnightHealth >= 420.0f || KnightHealth >= 350.0f)
    //    {
    //        KnightHealth = 420.0f;
    //    }
    //    else if (KnightHealth <= 350.0f)
    //    {
    //        KnightHealth += 70.0f;
    //    }

    //    if (RangerHealth >= 385.0f || KnightHealth >= 315.0f)
    //    {
    //        RangerHealth = 385.0f;
    //    }
    //    else if (RangerHealth <= 315.0f)
    //    {
    //        RangerHealth += 70.0f;
    //    }

    //    if (MageHealth >= 365.0f || MageHealth >= 295.0f)
    //    {
    //        MageHealth = 365.0f;
    //    }
    //    else if (MageHealth <= 295.0f)
    //    {
    //        MageHealth += 70.0f;
    //    }

    //    if (PriestHealth >= 365.0f || PriestHealth >= 295.0f)
    //    {
    //        PriestHealth = 365.0f;
    //    }
    //    else if (PriestHealth <= 295.0f)
    //    {
    //        PriestHealth += 70.0f;
    //    }
    //}
    //public override void P2Fire3(bool value)
    //{
    //    GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
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
    //    GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
    //}

    //public override void P3Fire2(bool value)
    //{

    //    if (KnightHealth >= 420.0f || KnightHealth >= 350.0f)
    //    {
    //        KnightHealth = 420.0f;
    //    }
    //    else if (KnightHealth <= 350.0f)
    //    {
    //        KnightHealth += 70.0f;
    //    }

    //    if (RangerHealth >= 385.0f || KnightHealth >= 315.0f)
    //    {
    //        RangerHealth = 385.0f;
    //    }
    //    else if (RangerHealth <= 315.0f)
    //    {
    //        RangerHealth += 70.0f;
    //    }

    //    if (MageHealth >= 365.0f || MageHealth >= 295.0f)
    //    {
    //        MageHealth = 365.0f;
    //    }
    //    else if (MageHealth <= 295.0f)
    //    {
    //        MageHealth += 70.0f;
    //    }

    //    if (PriestHealth >= 365.0f || PriestHealth >= 295.0f)
    //    {
    //        PriestHealth = 365.0f;
    //    }
    //    else if (PriestHealth <= 295.0f)
    //    {
    //        PriestHealth += 70.0f;
    //    }
    //}
    //public override void P3Fire3(bool value)
    //{
    //    GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
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
    //    GameObject Smite = Instantiate(Holy, HolyPoint.transform.position, HolyPoint.transform.rotation);
    //}

    //public override void P4Fire2(bool value)
    //{

    //    if (KnightHealth >= 420.0f || KnightHealth >= 350.0f)
    //    {
    //        KnightHealth = 420.0f;
    //    }
    //    else if (KnightHealth <= 350.0f)
    //    {
    //        KnightHealth += 70.0f;
    //    }

    //    if (RangerHealth >= 385.0f || KnightHealth >= 315.0f)
    //    {
    //        RangerHealth = 385.0f;
    //    }
    //    else if (RangerHealth <= 315.0f)
    //    {
    //        RangerHealth += 70.0f;
    //    }

    //    if (MageHealth >= 365.0f || MageHealth >= 295.0f)
    //    {
    //        MageHealth = 365.0f;
    //    }
    //    else if (MageHealth <= 295.0f)
    //    {
    //        MageHealth += 70.0f;
    //    }

    //    if (PriestHealth >= 365.0f || PriestHealth >= 295.0f)
    //    {
    //        PriestHealth = 365.0f;
    //    }
    //    else if (PriestHealth <= 295.0f)
    //    {
    //        PriestHealth += 70.0f;
    //    }
    //}
    //public override void P4Fire3(bool value)
    //{
    //    GameObject Consecration = Instantiate(SacredGround, SacredGroundPoint.transform.position, SacredGroundPoint.transform.rotation);
    //}
    //public override void P4Fire4(bool value)
    //{
    //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //    isGrounded = false;
    //}
}