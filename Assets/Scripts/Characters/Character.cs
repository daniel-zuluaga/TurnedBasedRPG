using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Conpoments")]
    public CharacterEffect characterEffect;
    public CharacterUI characterUI;
    public GameObject selectorVisual;
    public DamageFlash damageFlash;

    [Header("Prefabs")]
    public GameObject HealParticlePrefab;

    private Vector3 standingPosition;




}
