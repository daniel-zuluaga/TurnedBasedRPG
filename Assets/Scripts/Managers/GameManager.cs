using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Character[] playerTeam;
    public Character[] enemyTeam;

    private List<Character> allCharacters = new List<Character>();

    [Header("Components")]
    public Transform[] playerTeamSpawns;
    public Transform[] enemyTeamSpawns;

    [Header("Data")]
    public PlayerPersistentData playerPersistentData;
    public CharacterSet defaultEnemySet;
     
    public static GameManager instance;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        CreateCharacters(playerPersistentData, defaultEnemySet);
        TurnManager.instance.Begin();
    }

    void CreateCharacters(PlayerPersistentData playerData, CharacterSet enemyTeamSet)
    {
        playerTeam = new Character[playerData.characters.Length];
        enemyTeam = new Character[enemyTeamSet.characters.Length];

        int playerSpawnIndex = 0;

        for(int i = 0; i <playerData.characters.Length; i++ )
        {
            if (!playerData.characters[i].isDead)
            {
                Character character = CreateCharacter(playerData.characters[i].characterPrefab, playerTeamSpawns[playerSpawnIndex]);
                character.curHp = playerData.characters[i].health;
                playerTeam[i] = character;
                playerSpawnIndex++;

            }
            else
            {
                playerTeam[i] = null;
            }
        }

        for(int i = 0; i < enemyTeamSet.characters.Length; i++)
        {
            Character character = CreateCharacter(enemyTeamSet.characters[i], enemyTeamSpawns[i]);
            enemyTeam[i] = character;
        }
        allCharacters.AddRange(playerTeam);
        allCharacters.AddRange(enemyTeam);


    }

    Character CreateCharacter (GameObject characterPrefab , Transform spawnPos)
    {
        GameObject obj = Instantiate(characterPrefab, spawnPos.position, spawnPos.rotation);
        return obj.GetComponent<Character>();

    }

    public void OnCharacterKilled(Character character)
    {
        allCharacters.Remove(character);

        int playersRemaining = 0;
        int EnemiesRemaining = 0;

        for(int i = 0; i < allCharacters.Count; i++)
        {
            if (allCharacters[i].team == Character.Team.Player)
                playersRemaining++;
            else
                EnemiesRemaining++;
        }

        if(EnemiesRemaining == 0)
        {
            PlayerTeamWins();
        }
        else if(playersRemaining == 0)
        {
            EnemyTeamWins();
        }

    }

    void PlayerTeamWins()
    {
        UpdatePlayerPersistentData();
        Invoke(nameof(LoadMapScene), 1.0f);

    }

    void EnemyTeamWins()
    {
        playerPersistentData.ResetCharacters();
        Invoke(nameof(LoadMapScene), 1.0f);

    }

    void UpdatePlayerPersistentData()
    {
        for(int i = 0; i < playerTeam.Length; i++)
        {
            if(playerTeam[i] != null)
            {
                playerPersistentData.characters[i].health = playerTeam[i].curHp;
            }
            else
            {
                playerPersistentData.characters[i].isDead = true; 
            }
        }
    }

    void LoadMapScene()
    {
        SceneManager.LoadScene("Map");
    }

}
