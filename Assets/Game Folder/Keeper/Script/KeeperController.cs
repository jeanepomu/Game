using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    //som do inimigo Keepeer

    public AudioSource audioSource;
    public AudioClip dieSound;

    public Transform skin;
    public Transform keeperRange;

    public bool goRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {

            audioSource.PlayOneShot(dieSound, 0.5f);
            keeperRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
        }

        if (skin.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("KeeperAttack"))
        {
            return;        
        }


        if(goRight == true)
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                goRight = false;
                
            }

            transform.position = Vector2.MoveTowards(transform.position, b.position, 1.5f * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                goRight = true;


            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, 1.5f * Time.deltaTime);
        }
        
    }
}
