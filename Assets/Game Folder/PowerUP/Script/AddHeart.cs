using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHeart : MonoBehaviour
{
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Aumenta a vida do player
            collision.GetComponent<Character>().life++;

            // Toca o áudio do coração
            audioSource.Play();

            // Destrói o coração depois do som terminar
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
