using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private Renderer[] render;

    void Start()
    {
        render = GetComponentsInChildren<Renderer>();
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());

        IEnumerator FlashCoroutine()
        {
            SetMREmision(Color.red);

            yield return new WaitForSeconds(0.5f);

            SetMREmision(Color.black);
        }
    }

    void SetMREmision(Color color)
    {
        for(int i = 0; i < render.Length; i++)
        {
            render[i].material.SetColor("_EmissionColor", color);
        }
    }

}
