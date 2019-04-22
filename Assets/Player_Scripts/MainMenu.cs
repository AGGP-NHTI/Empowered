using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    string CharacterSelectScene = "CharacterSelection";
    string TutorialSelectScene = "TutorialScene";
    public void PlayGame()
    {
        SceneManager.LoadScene(CharacterSelectScene);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(TutorialSelectScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }






}
