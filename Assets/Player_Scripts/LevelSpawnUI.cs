using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpawnUI : MonoBehaviour
{

    public Canvas levelCanvas; 

    public List<Vector3> UIspawnLocations; 
    void Start()
    {
        int count = SceneTransition.instance.ControlerList.Count; 
        for (int i =0; i < count; i++)
        {
            SceneTransition.instance.ControlerList[i].SpawnUI(UIspawnLocations[i], levelCanvas);
        }
        
    }
}
