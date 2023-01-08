using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float viewDistance;
    [SerializeField] private GameObject player;
    [SerializeField] private float hitLength;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Animator animator;
    PlayerController playerController;

    internal bool attacking;
    internal bool dead;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        playerController= player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            Vector3 dist = player.transform.position - transform.position;

            if (Vector3.Angle(transform.forward, dist) < 360 / 2)
            {

                if (Physics.Raycast(transform.position, dist.normalized, out RaycastHit hit, viewDistance))
                {
                    animator.SetBool("SeePlayer", true);
                    if (hit.collider.CompareTag("Player") && !animator.GetBool("AttackPlayer"))
                    {
                        agent.destination = player.transform.position;

                        if (hit.distance < hitLength && !playerController.safe) { animator.SetBool("AttackPlayer", true); playerController.TakeHit(); }

                    }
                }
            }
        }
    }
}
