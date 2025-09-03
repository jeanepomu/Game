using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartialController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public AudioSource audioSource;
    public AudioClip dieSound;

    public Transform skin;
    [SerializeField] private Transform martialRange;

    public bool goRight;

    private Character character;
    private CapsuleCollider2D capsuleCollider;
    private CircleCollider2D rangeCollider;
    private Animator animator;

    void Start()
    {
        // Cache de componentes para evitar chamadas repetidas
        character = GetComponent<Character>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = skin != null ? skin.GetComponent<Animator>() : null;
        rangeCollider = martialRange != null ? martialRange.GetComponent<CircleCollider2D>() : null;

        // Verificações de segurança
        if (character == null)
            Debug.LogError("Character component não encontrado!");
        if (capsuleCollider == null)
            Debug.LogError("CapsuleCollider2D não encontrado!");
        if (animator == null)
            Debug.LogError("Animator não encontrado no skin!");
        if (rangeCollider == null)
            Debug.LogError("CircleCollider2D não encontrado no martialRange!");
    }

    void Update()
    {
        if (character != null && character.life <= 0)
        {
            if (audioSource != null && dieSound != null)
                audioSource.PlayOneShot(dieSound, 0.5f);

            if (rangeCollider != null)
                rangeCollider.enabled = false;

            if (capsuleCollider != null)
                capsuleCollider.enabled = false;

            this.enabled = false;
            return;
        }

        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("MartialAttack"))
            return;

        // Movimento
        if (goRight)
        {
            if (skin != null)
                skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
                goRight = false;

            transform.position = Vector2.MoveTowards(transform.position, a.position, 1.5f * Time.deltaTime);
        }
        else
        {
            if (skin != null)
                skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
                goRight = true;

            transform.position = Vector2.MoveTowards(transform.position, b.position, 1.5f * Time.deltaTime);
        }
    }
}
