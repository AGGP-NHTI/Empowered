using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect2 : EmpController
{
    private int selectedCharacterIndex1;
    private Color desiredColor;



    [Header("List of Characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColor;


    [Header("Sounds")]
    [SerializeField] private AudioClip arrowClickSfx;
    [SerializeField] private AudioClip CharSelectMusic;

    [Header("Options")]
    [SerializeField] private float backgroundColorTransitionSpeed = 5f;



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
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterIndex1, characterList[selectedCharacterIndex1].characterName));
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        this.SpawnPreFab = characterList[selectedCharacterIndex1].selectedchar;

        if (SceneTransition.SelectedCharacter2Confirm != 1)
        {
            SceneTransition.SelectedCharacter2Confirm++;
        }

    }


    public void LeftArrow()
    {
        selectedCharacterIndex1--;
        if (selectedCharacterIndex1 < 0)
        {
            selectedCharacterIndex1 = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }
    public void RightArrow()
    {
        selectedCharacterIndex1++;
        if (selectedCharacterIndex1 == characterList.Count)
        {
            selectedCharacterIndex1 = 0;
        }

        UpdateCharacterSelectionUI();
    }


    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex1].splash;
        characterName.text = characterList[selectedCharacterIndex1].characterName;
        desiredColor = characterList[selectedCharacterIndex1].characterColor;


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
