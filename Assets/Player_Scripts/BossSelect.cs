using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossSelect : MonoBehaviour
{
    protected int selectedCharacterIndex4;
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
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterIndex4, characterList[selectedCharacterIndex4].characterName));
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        BossController.SpawnPreFab4 = characterList[selectedCharacterIndex4].selectedchar;

        if (SceneTransition.SelectedCharacter4Confirm != 1)
        {
            SceneTransition.SelectedCharacter4Confirm++;
        }

    }


    public void LeftArrow()
    {
        selectedCharacterIndex4--;
        if (selectedCharacterIndex4 < 0)
        {
            selectedCharacterIndex4 = characterList.Count - 1;
        }

        UpdateCharacterSelectionUI();
    }
    public void RightArrow()
    {
        selectedCharacterIndex4++;
        if (selectedCharacterIndex4 == characterList.Count)
        {
            selectedCharacterIndex4 = 0;
        }

        UpdateCharacterSelectionUI();
    }


    private void UpdateCharacterSelectionUI()
    {
        characterSplash.sprite = characterList[selectedCharacterIndex4].splash;
        characterName.text = characterList[selectedCharacterIndex4].characterName;
        desiredColor = characterList[selectedCharacterIndex4].characterColor;


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
