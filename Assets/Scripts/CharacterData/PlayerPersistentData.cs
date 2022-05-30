using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Presistent Data" , menuName = "New Player Persistent Data")]
public class PlayerPersistentData : ScriptableObject
{
    public PlayerPresistentCharacter[] characters;

#if UNITY_EDITOR

    void OnValidate()
    {
        ResetCharacters();
    }

#endif

    public void ResetCharacters()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].health = characters[i].characterPrefabs.GetComponent<Character>().maxHp;
            characters[i].isDead = false;
           
        }
    }
}
