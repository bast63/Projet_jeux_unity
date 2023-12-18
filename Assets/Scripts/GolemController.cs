using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemController : MonoBehaviour
{
    //Distance entre le joueur et l'ennemi
    private float Distance;

    // Cible de l'ennemi
    public Transform Target;

    //Distance de poursuite
    public float chaseRange = 10;

    // Portée des attaques
    public float attackRange = 2.2f;

    // Cooldown des attaques
    public float attackRepeatTime = 1;
    private float attackTime;

    // Agent de navigation
    private NavMeshAgent agent;

    // Animations de l'ennemi
    private Animation animations;

    // Vie de l'ennemi
    private bool IsDead = false;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animations = gameObject.GetComponent<Animation>();
        attackTime = Time.time;
    }

    // Poursuite
    void Chase()
    {
        animations.Play("walk");
        agent.destination = Target.position;
    }

    // Combat
    void Attack()
    {
        // Si pas de cooldown
        if (Time.time > attackTime)
        {
            animations.Play("hit2");
            attackTime = Time.time + attackRepeatTime;
        }
    }

    // Idle
    void Idle()
    {
        animations.Play("idle");
    }

    void Update()
    {

        if (!IsDead)
        {

            // On cherche le joueur en permanence
            Target = GameObject.Find("Player").transform;

            // On calcule la distance entre le joueur et l'ennemi, en fonction de cette distance on effectue diverses actions
            Distance = Vector3.Distance(Target.position, transform.position);

            // Quand l'ennemi est loin = idle
            if (Distance > chaseRange)
            {
                Idle();
            }

            // Quand l'ennemi est proche mais pas assez pour attaquer
            if (Distance < chaseRange && Distance > attackRange)
            {
                Chase();
            }

            // Quand l'ennemi est assez proche pour attaquer
            if (Distance < attackRange)
            {
                Attack();
            }
        }
    }
}
