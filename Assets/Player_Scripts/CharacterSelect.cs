﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : PlayerPawn
{
    protected int selectedCharacterIndex;
    private Color desiredColor;


    [Header("Player Info")]
    public int playerNumber = 0;
    public EmpController EMPController;
    private bool HasSelectedCharacter = false; 

    [Header("List of Characters")]
    [SerializeField] protected List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] protected TextMeshProUGUI characterName;
    [SerializeField] protected Image characterSplash;
    [SerializeField] protected Image backgroundColor;
    [SerializeField] protected GameObject UIforplayer;


    [Header("Sounds")]
    [SerializeField] protected AudioClip arrowClickSfx;
    [SerializeField] protected AudioClip CharSelectMusic;

    [Header("Options")]
    [SerializeField] protected float backgroundColorTransitionSpeed = 5f;



    public override void Start()
    {
        //Debug.Log("Character Select Start"); 
        EMPController.PossesPawn(gameObject); 
        UpdateCharacterSelectionUI();
       
    }




    public void Update()
    {
        if (this.gameObject.tag == "CharacterSelection")
        {
            backgroundColor.color = Color.Lerp(backgroundColor.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        }

       
    }
    
    public override void Fire4(bool value)
    {
        ConfirmSelection();
    }

    public override void Fire5(bool value)
    {
        LeftArrow();
    }

    public override void Fire6(bool value)
    {
        RightArrow(); 
    }


    public void ConfirmSelection()
    {

        string output = "Player " + EMPController.InputPlayerNumber + " - "
                +"Character "+selectedCharacterIndex+":"
                + characterList[selectedCharacterIndex].characterName + "has been chosen";

        Debug.Log(output);


        if (!HasSelectedCharacter)
        {
            EMPController.UIPreFab = characterList[selectedCharacterIndex].selectedcharUI;
            EMPController.SpawnPreFab = characterList[selectedCharacterIndex].selectedchar;
            SceneTransition.PlayerHasConfirmed(playerNumber); 
            HasSelectedCharacter = true; 
            
        }
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
        characterName.text = characterList[selectedCharacterIndex].characterName;
        desiredColor = characterList[selectedCharacterIndex].characterColor;


    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColor;
        public GameObject selectedchar;
        public GameObject selectedcharUI;
    }
}
