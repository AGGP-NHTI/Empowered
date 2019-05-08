using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public static DontDestroy instance; 

    private void Awake()
    {
        if ((instance) && (instance != this))
        {
            // another instance exists, we thus
            Destroy(gameObject);
            return; 
        }
        instance = this;
        SceneTransition.instance = gameObject.GetComponent<SceneTransition>();
        DontDestroyOnLoad(gameObject);
    }
}
