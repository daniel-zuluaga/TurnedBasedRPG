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

    void OnEnable()
    {
        TurnManager.instance.onNewTurn += OnNewTurn;
    }

    void OnDisable()
    {
        TurnManager.instance.onNewTurn -= OnNewTurn;

    }

    void Start()
    {
        standingPosition = transform.position;
        characterUI.SetCharacterNameText(displayName);
        characterUI.UpdateHealthBar(curHp, maxHp);
    }

    void OnNewTurn()
    {
        characterUI.ToggleTurnVisual(TurnManager.instance.GetCurrentTurnCharacter() == this);
        characterEffect.ApplyCurrentEffects();
    }

    public void CastCombatAction(CombatAction combatAction, Character target = null)
    {
        if (target == null)
            target = this;

        combatAction.Cast(this, target);

    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        characterUI.UpdateHealthBar(curHp, maxHp);

        damageFlash.Flash();

        if (curHp <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        curHp += amount;

        if(curHp > maxHp)
        {
            curHp = maxHp;
        }

        characterUI.UpdateHealthBar(curHp, maxHp);
        Instantiate(HealParticlePrefab, transform);

    }

    void Die()
    {
        Destroy(gameObject); 
    }

    public void MoveToTarget(Character target, UnityAction<Character> arriveCallBacks)
    { 
        StartCoroutine(MeleeAttackAnimation());

        if (target == null)
        {
            return;
        }

        IEnumerator MeleeAttackAnimation()
        {
            while (transform.position != target.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
                yield return null;
            }

            arriveCallBacks?.Invoke(target);

            while (transform.position != standingPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, standingPosition, 10 * Time.deltaTime);
                yield return null;
            }
        }
    }

    public void ToggleSelectionVisual(bool toggle)
    {
        selectorVisual.SetActive(toggle);
    }

}
