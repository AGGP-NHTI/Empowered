using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    string CharacterSelectScene = "CharacterSelection";
    string TutorialSelectScene = "TutorialScene";
    public GameObject MainMenuObject;
    public GameObject OptionsMenuObject;
    public GameObject CreditsMenuObject;


    private void Update()
    {
        if (MainMenuObject.activeSelf)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PlayGame();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                PlayTutorial();
            }
            if (Input.GetButtonDown("Fire3"))
            {
                PlayOptions();
            }
            if (Input.GetButtonDown("Fire4"))
            {
                QuitGame();
            }
        }

        if (OptionsMenuObject.activeSelf)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PlayCreditsMenu();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                PlayMainMenu();
            }
            
        }
        if (CreditsMenuObject.activeSelf)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                BackFromCreditsMenu();
            }

          
        }


    }




    public void PlayGame()
    {
        SceneManager.LoadScene(CharacterSelectScene);
    }
    public void PlayMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(TutorialSelectScene);
    }

    public void PlayOptions()
    {
        OptionsMenuObject.SetActive(true);
        MainMenuObject.SetActive(false);
       
    }
    public void PlayMainMenu()
    {
        MainMenuObject.SetActive(true);
        OptionsMenuObject.SetActive(false);

    }
    public void PlayCreditsMenu()
    {
        CreditsMenuObject.SetActive(true);
        OptionsMenuObject.SetActive(false);
    }
    public void BackFromCreditsMenu()
    {
        CreditsMenuObject.SetActive(false);
        OptionsMenuObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }

}
