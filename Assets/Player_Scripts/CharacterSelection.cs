using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    protected int selectedCharacterIndex1;
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
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterIndex1, characterList[selectedCharacterIndex1].characterName));
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        EmpController.SpawnPreFab = characterList[selectedCharacterIndex1].selectedchar;
        if (SceneTransition.SelectedCharacterConfirm != 1)
        {
            SceneTransition.SelectedCharacterConfirm++;
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
