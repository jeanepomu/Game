using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public Transform player;

    public float attackTime;

    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {

            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            this.enabled = false;

        }


        if (Vector2.Distance(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center) > 0.9f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center, 2.7f * Time.deltaTime);


        }
        else if (player.GetComponent<Character>().life > 0) // Verifica se o personagem ainda est� vivo
        {
            attackTime += Time.deltaTime;
            if (attackTime >= 0.6f)
            {
                attackTime = 0;
                player.GetComponent<Character>().PlayerDamage(1);
            }
        }
        
    }
}