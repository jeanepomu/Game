using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour

{
    public AudioSource audioSource;
    public AudioClip groundedSound;
    internal static Vector2 position;
   
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            audioSource.PlayOneShot(groundedSound, 0.3f);
            audioSource.PlayOneShot(groundedSound);
        }
    }


}