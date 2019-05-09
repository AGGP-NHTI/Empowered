using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    //private void Update()
    //{
    //    if(GameObject.FindGameObjectWithTag("CharacterSelection"))
    //    {
    //        Destroy(this);
    //    }
    //}
}
