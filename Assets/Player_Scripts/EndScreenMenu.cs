using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenMenu : MonoBehaviour
{

    string CharacterSelectScene = "CharacterSelection";
    string TutorialSelectScene = "TutorialScene";
    public GameObject MainMenuObject;
    public GameObject OptionsMenuObject;
    public GameObject CreditsMenuObject;

    private void Start()
    {
        
        Destroy(GameObject.FindGameObjectWithTag("StartingArena"));
        foreach(GameObject GObject in GameObject.FindGameObjectsWithTag("Controllers"))
        {
            Destroy(GObject);
        }
            
            

        SceneTransition[] controllers = GameObject.FindObjectsOfType<SceneTransition>();

        foreach(SceneTransition controller in controllers)
        {
            SceneTransition.ResetConfirmedArray();
        }
    }
    private void Update()
    {
            if (Input.GetButtonDown("Fire4"))
            {

            SceneTransition.SelectedCharacterConfirm = 0;
            PlayGame();
            }

            
            if (Input.GetButtonDown("Fire1"))
            {

            SceneTransition.SelectedCharacterConfirm = 0;
            PlayMain();
            }
            if (Input.GetButtonDown("Fire3"))
            {

                QuitGame();
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
