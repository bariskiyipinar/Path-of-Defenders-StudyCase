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
    [SerializeField] private AudioSource punchSound;
    void Start()
    {
        animator = GetComponent<Animator>();

        if (PunchPower != null)
        {
            PunchPower.Stop();
            PunchPower.gameObject.SetActive(false);
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
            
            animator.SetTrigger("IsAttack");



            PunchPower.gameObject.SetActive(true);
            if (PunchPower != null && !PunchPower.isPlaying)
            {
                PunchPower.Play();
            }

    
            closestEnemy.EnemyTakeDamage(1);

            lastAttackTime = Time.time;
        }
        else
        {
            animator.SetBool("IsIdle", true);



            if (punchSound != null && punchSound.isPlaying)
            {
                punchSound.Stop();  
            }
        }
    }

    public void PlayPunchSound()
    {
        if (punchSound != null)
            punchSound.Play();
    }

}
