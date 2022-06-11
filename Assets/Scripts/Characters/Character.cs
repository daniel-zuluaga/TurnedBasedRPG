using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Character : MonoBehaviour
{
    public enum Team
    {
        Player,
        Enemy 
    }

    [Header("Stats")]
    public Team team;
    public string displayName;
    public int curHp;
    public int maxHp;

    [Header("Combat Actions")]
    public CombatAction[] combatActions;

    [Header("Components")]
    public CharacterEffect characterEffect;
    public CharacterUI characterUI;
    public GameObject selectorVisual;
    public DamageFlash damageFlash;

    [Header("Prefabs")]
    public GameObject HealParticlePrefab;

    private Vector3 standingPosition;

    private void OnEnable()
    {
        TurnManager.instance.onNewTurn += OnNewTurn;
    }

    private void OnDisable()
    {
        TurnManager.instance.onNewTurn -= OnNewTurn;

    }

    void OnNewTurn()
    {
        characterUI.ToggleTurnVisual(TurnManager.instance.GetCurrentTurnCharacter() == this);
    }

    public void CastCombatAction(CombatAction combatAction, Character target = null)
    {

    }

    public void TakeDamage(int damage)
    {

    }

    public void Heal(int amount)
    {

    }

    void Die()
    {

    }

    public void MoveToTarget(Character target, UnityAction<Character> arriveCallBacks)
    {

    }

    public void ToggleSelectionVisual(bool toggle)
    {
        selectorVisual.SetActive(toggle);
    }

}
