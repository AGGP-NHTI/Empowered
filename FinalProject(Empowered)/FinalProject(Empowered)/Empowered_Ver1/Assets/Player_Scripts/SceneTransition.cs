using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static int NextPlayerArenaCount = 0;
    public static int NextBossArenaCount = 0;
    public Text NextPlayerArenaCountText;
    public Text NextBossArenaCountText;
    string ArenaStarting = "StartingArena";
    string ArenaTwoScenePlayer1 = "PlayerWinArenaOne(Leech)";
    string ArenaTwoSceneBoss1 = "BossWinArenaOne(Leech)";
    string ArenaThreeScenePlayer2 = "PlayerWinArenaTwo(Pit)";
    string ArenaThreeSceneBoss2 = "BossWinArenaTwo(Pit)";
    string Menu = "MainMenu";
    public void Update()
    {
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
                SceneManager.LoadScene(Menu);
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
                SceneManager.LoadScene(Menu);
            }
        }
        if (this.gameObject.tag == "BossWinArenaOne(Leech)")
        {
            if (NextPlayerArenaCount == 1)
            {
                SceneManager.LoadScene(ArenaStarting);
            }
        }
        NextBossArenaCountText.text = "Player Deaths: " + NextBossArenaCount;
        NextPlayerArenaCountText.text = "Boss Death: " + NextPlayerArenaCount;
    }
}
