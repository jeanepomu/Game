using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{

    Transform player;
    public Transform skin;

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
       if (collision.CompareTag("Player"))
        {
            skin.GetComponent<Animator>().Play("Stuck", -1);

            collision.transform.position = new Vector3(gameObject.transform.position.x,collision.transform.position.y,collision.transform.position.z);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().SetBool("PlayerRun", false);
            collision.GetComponent<PlayerController>().skin.GetComponent<Animator>().Play("PlayerIdle", -1);

            GetComponent<BoxCollider2D>().enabled = false;

            player = collision.transform;

            collision.GetComponent<PlayerController>().enabled = false;

            Invoke("ReleasePlayer", 2);

        }
      
    }

    void ReleasePlayer()
    {
        player.GetComponent<PlayerController>().enabled = true;    
    }


}
