using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Transform palyer;



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
        if (collision.CompareTag("Enemy"))
        {
            if (palyer.GetComponent<PlayerController>().comboNum == 1)
            {
                collision.GetComponent<Character>().life--;
            }
            
            if (palyer.GetComponent<PlayerController>().comboNum == 2)
            {
                collision.GetComponent<Character>().life -=  2;
            }
           
        }
    }


}

