using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect Combat Action", menuName = "CombatActions/Effect Combat Action")]
public class EffectCombatAction : CombatAction
{ 
    // public Effects effectToCast;
    public bool canEffectSelf;
    public bool canEffectTeam;
    public bool canEffectEnemy;


    public override void Cast(Character caster, Character target)
    {
        throw new System.NotImplementedException();
    }
}
