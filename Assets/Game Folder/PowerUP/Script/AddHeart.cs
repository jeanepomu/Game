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
            // Aumenta a vida
            collision.GetComponent<Character>().life++;

            // Toca o som no espaço, independente do coração existir
            AudioSource.PlayClipAtPoint(sound, transform.position);

            // Some imediatamente
            Destroy(gameObject);
        }
    }
}
