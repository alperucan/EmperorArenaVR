using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyDefinition definition;
    private List<Stat> stats;

    public DynamicStat health;
    public DynamicStat mana;
    private bool isDead;
    private float timeUntilCanBeDamaged;

    private Animator animator;
    private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;
    private Transform target;
    public Transform Target => target;

    public event Action OnDied;
    public event Action<int> OnTakeDamage;

    public float fieldofVisionAngle = 135f;
    public float fieldofVisionRadius = 3f;
    public float patrolDistance = 2.5f;
    public float attackRange = 1f;
    public float timeUntilNextAttack;
    public float attcktSpeed = 0.25f;
    public float patrollingSpeed = 2f;

    public LayerMask playerLayer;
    private Collider[] hitColliders = new Collider[1];
    private static readonly int Attacking = Animator.StringToHash("attacking");
    private static readonly int Following = Animator.StringToHash("following");
    private static readonly int MovementSpeed = Animator.StringToHash("movementSpeed");
    private static readonly int Dead = Animator.StringToHash("dead");
    private static readonly int Hit = Animator.StringToHash("hit");

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        stats = new List<Stat>();
        
        foreach (var baseStat in definition.baseStats)
        {
            stats.Add(new Stat(baseStat.name,baseStat.BaseValue));
        }

        health = new DynamicStat(definition.health.name, definition.health.BaseValue);
        mana = new DynamicStat(definition.mana.name, definition.mana.BaseValue);
    }

    private void OnEnable()
    {
        SceneLinkedSMB<Enemy>.Initialise(animator, this);
    }

    private void Update()
    {
        animator.SetFloat(MovementSpeed, agent.velocity.magnitude/agent.speed);
    }

    private void FixedUpdate()
    {
        if (target)
        {
            animator.SetBool(Attacking, Physics.CheckSphere(transform.position, attackRange, playerLayer));
            animator.SetBool(Following, Physics.CheckSphere(transform.position, fieldofVisionRadius, playerLayer));
        }
        else
        {
            int numColliders =Physics.OverlapSphereNonAlloc(transform.position, fieldofVisionRadius, hitColliders, playerLayer);
            for (int i = 0; i < numColliders; i++)
            {
                Vector3 direction = hitColliders[i].transform.position - transform.position;

                float angle = Vector3.Angle(direction, transform.forward);

                if (angle <= fieldofVisionAngle)
                {
                    if (Physics.Raycast(transform.position + transform.up, direction.normalized, out RaycastHit hit,
                            fieldofVisionRadius))
                    {
                        target = hit.collider.transform;
                        animator.SetBool(Following, true);
                        break;
                    }
                }
            }
        }
    }

    public void TakeDamage(Stats playerStats)
    {
        if (isDead) return;
        
        if(Time.time < timeUntilCanBeDamaged)  return;

        if (!target)
        {
            target = playerStats.transform;
        }

        var damage = CalculateDamage(playerStats);

        health.CurrentValue -= damage;
        
        OnTakeDamage?.Invoke(damage);
        if (health.CurrentValue == 0)
        {
            animator.SetTrigger(Dead);
            isDead = true;
            
            
        }
        else
        {
            animator.SetTrigger(Hit);
            timeUntilCanBeDamaged = Time.time + 1.5f;
        }
    }

    public void Die()
    {
        OnDied?.Invoke();
        EventManager.Instance.EnemyDied(this);
        Destroy(gameObject);
    }

    private int CalculateDamage(Stats playerStats)
    {
        var physicalDefanse = stats.Find(stat => stat.name == StatType.PHYSICAL_DEFENSE);
        return playerStats[StatType.PHYSICAL_ATTACK].Value - physicalDefanse.Value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(transform.position,fieldofVisionRadius);
        Gizmos.color=Color.yellow;
        Gizmos.DrawWireSphere(transform.position,patrolDistance);
        
    }
}