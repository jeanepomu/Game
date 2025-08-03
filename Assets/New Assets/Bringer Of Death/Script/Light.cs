using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;  // Importante para Light2D

public class Light : MonoBehaviour
{
    public Light2D luz;
    public GameObject square;  // Referência ao objeto que será desativado
    private bool luzAtivada = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!luzAtivada && other.CompareTag("Player"))
        {
            luz.enabled = true;
            luzAtivada = true;

            if (square != null)
            {
                square.SetActive(false);  // Desativa o square
            }
        }
    }

    // OnTriggerExit removido para que a luz fique sempre acesa
}
