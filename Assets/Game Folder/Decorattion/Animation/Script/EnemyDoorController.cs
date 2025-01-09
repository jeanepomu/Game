using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorController : MonoBehaviour
{
    int lifeChange;

    // Start is called before the first frame update
    void Start()
    {
        lifeChange = GetComponent<Character>().life;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeChange != GetComponent<Character>().life)
        {
            lifeChange = GetComponent<Character>().life;
            GetComponent<Character>().skin.GetComponent<Animator>().Play("EnemyDoorDamage", -1);
        }
        
        if(GetComponent<Character>().life <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
