using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : PlayerPawn
{
    protected int selectedCharacterIndex;

    [Header("List of Characters")]
    [SerializeField] protected List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();



    [Header("UI References")]
    
    [SerializeField] protected Image characterSplash;
 

    [Header("Sounds")]
    [SerializeField] protected AudioClip arrowClickSfx;
    [SerializeField] protected AudioClip CharSelectMusic;

    public override void Start()
    {
        
        UpdateCharacterSelectionUI();

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire5"))
        {
            LeftArrow();
        }
        if (Input.GetButtonDown("Fire6"))
        {
            RightArrow();
        }
    }



    public void LeftArrow()
    {
        
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }
    public void RightArrow()
    {
      
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count)
        {
            selectedCharacterIndex = 0;
        }

        UpdateCharacterSelectionUI();
    }

    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex].splash;
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
    }
}


   
