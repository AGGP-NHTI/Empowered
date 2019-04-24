using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPin : MonoBehaviour
{
    public GameObject spin;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        spin.transform.Rotate(Vector3.up);
    }
}
