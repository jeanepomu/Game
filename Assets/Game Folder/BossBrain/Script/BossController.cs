using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == A.position)
        {
            targetPosition = B.position;
        }
        if (transform.position == B.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 5 * Time.deltaTime);
    }
}
