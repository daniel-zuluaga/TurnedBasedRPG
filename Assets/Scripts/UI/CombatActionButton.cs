using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatActionButton : MonoBehaviour
{
    public TextMeshProUGUI nameText;

    private CombatAction combatAction;
    private CombatActionUI ui;

    private void Awake()
    {
        ui = FindObjectOfType<CombatActionUI>();
    }

    public void SetCombatAction(CombatAction combat)
    {
        combatAction = combat;
        nameText.text = combat.displayName;
    }

    public void OnClick()
    {

    }

    public void OnHoverEnter()
    {
        ui.SetCombatActionDescription(combatAction);
    }

    public void OnHoverExit()
    {
        ui.DisableCombatActionDescription();
    }

}
