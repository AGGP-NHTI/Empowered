using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect3 : MonoBehaviour
{
    protected int selectedCharacterIndex3;
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



    private void Start()
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
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterIndex3, characterList[selectedCharacterIndex3].characterName));
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        EmpController3.SpawnPreFab3 = characterList[selectedCharacterIndex3].selectedchar;

        if (SceneTransition.SelectedCharacter3Confirm != 1)
        {
            SceneTransition.SelectedCharacter3Confirm++;
        }
    }


    public void LeftArrow()
    {
        selectedCharacterIndex3--;
        if (selectedCharacterIndex3 < 0)
        {
            selectedCharacterIndex3 = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }
    public void RightArrow()
    {
        selectedCharacterIndex3++;
        if (selectedCharacterIndex3 == characterList.Count)
        {
            selectedCharacterIndex3 = 0;
        }

        UpdateCharacterSelectionUI();
    }


    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex3].splash;
        characterName.text = characterList[selectedCharacterIndex3].characterName;
        desiredColor = characterList[selectedCharacterIndex3].characterColor;


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
