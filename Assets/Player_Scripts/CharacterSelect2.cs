using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect2 : MonoBehaviour
{
    protected int selectedCharacterIndex2;
    private Color desiredColor;

   

    [Header("List of Characters")]
    [SerializeField] protected List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] protected TextMeshProUGUI characterName;
    [SerializeField] protected Image characterSplash;
    [SerializeField] protected Image backgroundColor;


    [Header("Sounds")]
    [SerializeField] protected AudioClip arrowClickSfx;
    [SerializeField] protected AudioClip CharSelectMusic;

    [Header("Options")]
    [SerializeField] protected float backgroundColorTransitionSpeed = 5f;



    public void Start()
    {
        UpdateCharacterSelectionUI();
        
    }

    public void Update()
    {
        if (this.gameObject.tag == "CharacterSelection")
        {
            backgroundColor.color = Color.Lerp(backgroundColor.color, desiredColor, Time.deltaTime * backgroundColorTransitionSpeed);
        }
    }

    public void ConfirmSelection()
    {
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterIndex2, characterList[selectedCharacterIndex2].characterName));
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

         EmpController2.SpawnPreFab2 = characterList[selectedCharacterIndex2].selectedchar;

        if (SceneTransition.SelectedCharacter2Confirm != 1)
        {
            SceneTransition.SelectedCharacter2Confirm++;
        }

    }


    public void LeftArrow()
    {
        selectedCharacterIndex2--;
        if (selectedCharacterIndex2 < 0)
        {
            selectedCharacterIndex2 = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }
    public void RightArrow()
    {
        selectedCharacterIndex2++;
        if (selectedCharacterIndex2 == characterList.Count)
        {
            selectedCharacterIndex2 = 0;
        }

        UpdateCharacterSelectionUI();
    }


    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex2].splash;
        characterName.text = characterList[selectedCharacterIndex2].characterName;
        desiredColor = characterList[selectedCharacterIndex2].characterColor;


    }

    [System.Serializable]
    public class CharacterSelectObject
    {

        public Sprite splash;
        public string characterName;
        public Color characterColor;
        public GameObject selectedchar;
    }
}
