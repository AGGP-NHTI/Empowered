using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Singleton Setup
    public static SceneTransition instance; 
    // Singlton Check and Assignment controlled by DontDestroy Script

    [SerializeField] public static int SelectedCharacterConfirm = 0;

    public static int NextPlayerArenaCount = 0;
    public static int NextBossArenaCount = 0;
    static bool[] PlayersConfirmed = new bool[4];
    public GameObject spectator;
    public EmpController Player;
    

    string CharacterSelect = "CharacterSelection";
    string ArenaStarting = "StartingArena";
    string ArenaTwoScenePlayer1 = "PlayerWinArenaOne(Leech)";
    string ArenaTwoSceneBoss1 = "BossWinArenaOne(Leech)";
    string ArenaThreeScenePlayer2 = "PlayerWinArenaTwo(Pit)";
    string ArenaThreeSceneBoss2 = "BossWinArenaTwo(Pit)";

    
    public List<EmpController> ControlerList; 
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

    public void AllControllersSpectate()
    {
        foreach (EmpController c in ControlerList)
        {
            c.RequestSpectate(); 
        }
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

                SceneManager.LoadScene(ArenaStarting);

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                Player.PossesPawn(Player.SpectatorActor);

               // AllControllersSpectate(); 
                this.gameObject.tag = "StartingArena";

            }
        }
        if (this.gameObject.tag == "StartingArena")
        {
            if (NextPlayerArenaCount == 1)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                SceneManager.LoadScene(ArenaTwoScenePlayer1);
                if (this.gameObject.tag == "StartingArena")
                {
                    //Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                    //Player.PossesPawn(Player.SpectatorActor);
                }
                this.gameObject.tag = "PlayerWinArenaOne(Leech)";

            }
        }
        if (this.gameObject.tag == "StartingArena")
        {
            if (NextBossArenaCount == 3)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                SceneManager.LoadScene(ArenaTwoSceneBoss1);
                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
               

                Player.PossesPawn(Player.SpectatorActor);

                this.gameObject.tag = "PlayerWinArenaOne(Leech)";

                

            }
        }
        if (this.gameObject.tag == "PlayerWinArenaOne(Leech)")
        {
            if (NextPlayerArenaCount == 1)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(ArenaThreeScenePlayer2);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaOne(Leech)")
        {
            if (NextBossArenaCount == 3)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(ArenaStarting);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaTwo(Pit)")
        {
            if (NextPlayerArenaCount == 1)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                //Player2.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player2);
                //Player3.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player3);
                //Player4.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player4);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(CharacterSelect);
            }
        }
        if (this.gameObject.tag == "PlayerWinArenaTwo(Pit)")
        {
            if (NextBossArenaCount == 3)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                //Player2.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player2);
                //Player3.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player3);
                //Player4.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player4);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(ArenaTwoScenePlayer1);
            }
        }
        if (this.gameObject.tag == "BossWinArenaOne(Leech)")
        {
            if (NextBossArenaCount == 3)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                //Player2.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player2);
                //Player3.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player3);
                //Player4.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player4);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(ArenaThreeSceneBoss2);
            }
        }
        if (this.gameObject.tag == "BossWinArenaTwo(Pit)")
        {
            if (NextPlayerArenaCount == 1)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                //Player2.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player2);
                //Player3.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player3);
                //Player4.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player4);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(ArenaTwoSceneBoss1);
            }
        }
        if (this.gameObject.tag == "BossWinArenaTwo(Pit)")
        {
            if (NextBossArenaCount == 3)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                //Player2.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player2);
                //Player3.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player3);
                //Player4.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player4);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(CharacterSelect);
            }
        }
        if (this.gameObject.tag == "BossWinArenaOne(Leech)")
        {
            if (NextPlayerArenaCount == 1)
            {
                NextPlayerArenaCount = 0;
                NextBossArenaCount = 0;

                Player.SpectatorActor = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player);
                //Player2.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player2);
                //Player3.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player3);
                //Player4.SpectatorPreFab = Controller.Factory(spectator, Vector3.zero, Quaternion.identity, Player4);

                Player.PossesPawn(Player.SpectatorActor);

                // AllControllersSpectate(); 
                SceneManager.LoadScene(ArenaStarting);
            }
        }
      
    }

}
