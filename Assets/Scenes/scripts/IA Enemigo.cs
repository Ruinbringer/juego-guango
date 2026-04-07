using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform[] waypoints;

    [Header("Distances")]
    public float detectDistance = 8f;
    public float loseDistance = 12f;

    [Header("Speeds")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4.5f;

    NavMeshAgent agent;
    Animator animator;

    int index;
    bool chasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = patrolSpeed;

        GoNext();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // detectar jugador
        if (distance < detectDistance)
        {
            chasing = true;
        }

        // perder jugador
        if (distance > loseDistance)
        {
            chasing = false;
            GoNext();
        }

        // comportamiento
        if (chasing)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
        }
        else
        {
            Patrol();
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;

        if (!agent.pathPending && agent.remainingDistance < 0.3f)
        {
            GoNext();
        }
    }

    void GoNext()
    {
        if (waypoints.Length == 0)
            return;

        agent.SetDestination(waypoints[index].position);

        index++;

        if (index >= waypoints.Length)
            index = 0;
    }
}