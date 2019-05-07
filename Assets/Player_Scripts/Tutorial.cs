using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : Pawn
{
    protected int selectedCharacterIndex;




  
    public List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

  
     public TextMeshProUGUI characterName;
     public Image characterSplash;



    [Header("Sounds")]
    [SerializeField] protected AudioClip arrowClickSfx;
    [SerializeField] protected AudioClip CharSelectMusic;


  
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


   
