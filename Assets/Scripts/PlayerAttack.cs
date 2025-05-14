using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float timeBetweenAttacks = 1.5f;
    private float lastAttackTime;
    private Animator animator;
    [SerializeField] private ParticleSystem PunchPower;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (PunchPower != null)
        {
            PunchPower.Stop(); // Ba�lang��ta durdur
        }
    }

    void Update()
    {
        TryAttackClosestEnemy();
    }

    void TryAttackClosestEnemy()
    {
        if (Time.time - lastAttackTime < timeBetweenAttacks)
            return;

        EnemyAttack[] allEnemies = FindObjectsOfType<EnemyAttack>();

        EnemyAttack closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (EnemyAttack enemy in allEnemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist <= attackRange && dist < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = dist;
            }
        }

        if (closestEnemy != null)
        {
            // Sald�r� animasyonunu tetikle
            animator.SetTrigger("IsAttack");

            // Partik�l sistemini ba�lat (e�er durduysa)
            if (PunchPower != null && !PunchPower.isPlaying)
            {
                PunchPower.Play();
            }

            // En yak�n d��man� vur
            closestEnemy.EnemyTakeDamage(1);

            lastAttackTime = Time.time;
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }
    }
}
