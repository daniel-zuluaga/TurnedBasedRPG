using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

     


}
