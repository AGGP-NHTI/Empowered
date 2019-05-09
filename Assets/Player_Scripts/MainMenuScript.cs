using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenuScript : MonoBehaviour
{
   
    public GameObject TheCanvas;
    
    public static MainMenuScript instance;
   
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {     
        DontDestroyOnLoad(gameObject);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void EndGame()
    {
     
        SceneManager.LoadScene("MainMenu");
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if ("MainMenu" == scene.name)
        {
            Debug.Log("It's the MainMenu!");
           
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }
}