using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] public static int SelectedCharacterConfirm = 0;

    public static int NextPlayerArenaCount = 0;
    public static int NextBossArenaCount = 0;
    static bool[] PlayersConfirmed = new bool[4];
  
    string CharacterSelect = "CharacterSelection";
    string ArenaStarting = "StartingArena";
    string ArenaTwoScenePlayer1 = "PlayerWinArenaOne(Leech)";
    string ArenaTwoSceneBoss1 = "BossWinArenaOne(Leech)";
    string ArenaThreeScenePlayer2 = "PlayerWinArenaTwo(Pit)";
    string ArenaThreeSceneBoss2 = "BossWinArenaTwo(Pit)";

    public static void ResetConfirmedArray()
    {
        int index = 0; 
        foreach (bool b in PlayersConfirmed)
        {
            PlayersConfirmed[index] = false;
            index++; //hack 
        }
    }

    public static int GetConfirmedPlayers()
    {
        int result = 0;
        foreach (bool b in PlayersConfirmed)
        {
            if (b)
            {
                result++; 
            }
        }

        return result; 
    }


    public static void PlayerHasConfirmed(int PlayerNumber)
    {
        PlayersConfirmed[PlayerNumber-1] = true; 
    }

    public void Update()
    {
        if (this.gameObject.tag == "CharacterSelection")
        {
            if(GetConfirmedPlayers() == 4)
            {
                this.gameObject.tag = "StartingArena";
                SceneManager.LoadScene(ArenaStarting);
            }
        }
        if (this.gameObject.tag == "StartingArena")
        {
            if (NextPlayerArenaCount == 1)
            {
                SceneManager.LoadScene(ArenaTwoScenePlayer1);
            }
        }
        if (this.gameObject.tag == "StartingArena")
        {
            if (NextBossArenaCount == 3)
            {
                SceneManager.LoadScene(ArenaTwoSceneBoss1);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaOne(Leech)")
        {
            if (NextPlayerArenaCount == 1)
            {
                SceneManager.LoadScene(ArenaThreeScenePlayer2);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaOne(Leech)")
        {
            if (NextBossArenaCount == 3)
            {
                SceneManager.LoadScene(ArenaStarting);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaTwo(Pit)")
        {
            if (NextPlayerArenaCount == 1)
            {
                SceneManager.LoadScene(CharacterSelect);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaTwo(Pit)")
        {
            if (NextBossArenaCount == 3)
            {
                SceneManager.LoadScene(ArenaTwoScenePlayer1);
            }
        }
        if (this.gameObject.tag == "BossWinArenaOne(Leech)")
        {
            if (NextBossArenaCount == 3)
            {
                SceneManager.LoadScene(ArenaThreeSceneBoss2);
            }
        }
        if (this.gameObject.tag == "BossWinArenaTwo(Pit)")
        {
            if (NextPlayerArenaCount == 1)
            {
                SceneManager.LoadScene(ArenaTwoSceneBoss1);
            }
        }
        if (this.gameObject.tag == "BossWinArenaTwo(Pit)")
        {
            if (NextBossArenaCount == 3)
            {
                SceneManager.LoadScene(CharacterSelect);
            }
        }
        if (this.gameObject.tag == "BossWinArenaOne(Leech)")
        {
            if (NextPlayerArenaCount == 1)
            {
                SceneManager.LoadScene(ArenaStarting);
            }
        }
      
    }

}
