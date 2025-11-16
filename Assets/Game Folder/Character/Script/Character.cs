using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int life;
    public Transform skin;
    public Transform cam;
    public GameObject player;
    public Text heartCountText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0 && !transform.name.Equals("BossBrain"))
        {
            skin.GetComponent<Animator>().Play("Die", -1);
        }

        if (transform.CompareTag("Player"))
        {
            heartCountText.text = "x" + life.ToString();
        }
             
        if(transform.name.Equals("BossBrain"))
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(1.78f,  (life * 1.09f / 30f));
            
            if(life <= 0)
            
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    public void PlayerDamage(int value )
    {
        life = life - value;
        skin.GetComponent<Animator>().Play("PlayerDamage", 1);
        cam.GetComponent<Animator>().Play("CameraPlayerDamage", -1);
        GetComponent<PlayerController>().audioSource.PlayOneShot(GetComponent<PlayerController>().damageSound);
    }

    internal void TakeDamage(int v)
    {
        throw new NotImplementedException();
    }
}


