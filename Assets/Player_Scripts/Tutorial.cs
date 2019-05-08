using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : PlayerPawn
{
    protected int selectedCharacterIndex;




    private bool HasSelectedCharacter = false;
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
   

    public override void Fire5(bool value)
    {
        LeftArrow();
    }

    public override void Fire6(bool value)
    {
        RightArrow();
    }

    public void LeftArrow()
    {
        if (HasSelectedCharacter)
        {
            return;
        }

        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }
    public void RightArrow()
    {
        if (HasSelectedCharacter)
        {
            return;
        }

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


   
