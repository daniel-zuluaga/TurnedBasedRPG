using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    public float selectionCheckRate = 0.02f;
    private float lastSelectionCheckTime;
    public LayerMask selectionLayerMask;

    private bool isActive;

    private CombatAction curSelectionCombatAction;
    private Character curSelectedCharacter;

    // selection flags
    private bool canSelectSelf;
    private bool canSelectTeam;
    private bool canSelectEnemies;

    // Singleton
    public static PlayerCombatManager instance;

    [Header("Components")]
    public CombatActionUI combatActionUI;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    void OnNewTurn()
    {

    }

    void EnableCombatAction()
    {

    }

    void DisableCombatAction()
    {

    }

    void Update()
    {
            
    }

    void CastCombatAction()
    {

    }

    void SelectionCheck()
    {

    }

    void NextTurnDelay()
    {

    }

    void SelectCharacter(Character character)
    {

    }

    void UnSelectCharacter()
    {

    }

    public void SetCurrentCombatAction(CombatAction combatAction)
    {

    }

}
 