using UnityEngine;

public class CharacterCombatController : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackCooldown = 1.5f;
    public float moveSpeed = 0.1f;

    public Transform pointA;
    public Transform pointB;
    private Transform currentTarget;

    private float lastAttackTime;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentTarget = pointB;
    }

    void Update()
    {
        Patrol();

        // Você pode adicionar outras condições aqui, tipo quando atacar etc.
    }

    void Patrol()
    {
        if (currentTarget == null) return;

        Vector3 direction = currentTarget.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        transform.LookAt(currentTarget);

        if (direction.magnitude > 0.1f)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            // Alterna o destino ao chegar
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
            animator.SetTrigger("Idle");
        }
    }

    public void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            animator.SetTrigger("Attack");
            lastAttackTime = Time.time;

            Collider[] hitPlayers = Physics.OverlapSphere(transform.position + transform.forward, 0.5f);
            foreach (var hit in hitPlayers)
            {
                if (hit.CompareTag("Player")) 
                {
                    
                }
                   // hit.GetComponent<PlayerHealth>()?.TakeDamage(damageAmount);
            }
        }
    }

    // Outras animações
    public void Cast() => animator.SetTrigger("Cast");
    public void Spell() => animator.SetTrigger("Spell");
    public void Death() => animator.SetTrigger("Death");
    public void Hurt() => animator.SetTrigger("Hurt");
}