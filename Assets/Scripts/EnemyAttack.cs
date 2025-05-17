using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainUtils;
using UnityEngine.UI;

public enum EnemyType { EnemyGirl,EnemyMale,EnemyRobot}

public class EnemyAttack : MonoBehaviour
{
    private Transform player; 
    private NavMeshAgent agent;

    [SerializeField] private EnemyType enemyType;
    [SerializeField] private Image HealthBar;
    private float currentHealth;
    private float maxHealth = 5;

    private bool isDead = false;

    public float attackRange = 2f;
    public float timeBetweenAttacks = 1.5f;
    private float lastAttackTime;

    private Animator animator;

    private Canvas healthCanvas;
  
    private bool isColorRed = false;
    private SpriteRenderer sp;

    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        sp = GetComponent<SpriteRenderer>();

        healthCanvas = HealthBar.transform.GetComponentInParent<Canvas>();

      
        if (healthCanvas != null && Camera.main != null)
        {
            healthCanvas.renderMode = RenderMode.WorldSpace;
            healthCanvas.worldCamera = Camera.main; 
        }

        HealthBar.gameObject.SetActive(false);

        SetHealth();
    }


    private void Update()
    {

        if (isDead) return;
        if (agent == null || !agent.isOnNavMesh || !agent.enabled)
            return;


        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
           
            agent.isStopped = true;
            HealthBar.gameObject.SetActive(true);
            animator.SetBool("IsWalking", false);

            Attack();
        }
        else
        {
          
            if (agent.isStopped)
            {
                agent.isStopped = false;  
                HealthBar.gameObject.SetActive(false);
                animator.SetBool("IsWalking", true);

            }
        }
    }
 
    void Attack()
    {
        if (Time.time - lastAttackTime >= timeBetweenAttacks)
        {
            switch (enemyType)
            {
                case EnemyType.EnemyGirl:
                    animator.SetTrigger("IsAttack");

                    break;
                case EnemyType.EnemyMale:
                    animator.SetTrigger("IsAttack");
                    break;
                case EnemyType.EnemyRobot:
                    animator.SetTrigger("IsAttack");
                    break;
            }

            player.GetComponent<PlayerHealth>()?.TakeDamage(0.5f);
            lastAttackTime = Time.time;
        }
    }

    private void SetHealth()
    {

        switch (enemyType)
        {
            case EnemyType.EnemyGirl:
                currentHealth = maxHealth;
                break;
            case EnemyType.EnemyMale:
                currentHealth = maxHealth * 1.2f;
                break;
            case EnemyType.EnemyRobot:
                currentHealth = maxHealth * 1.3f;
                break;
        }


    }


    public void EnemyTakeDamage(int damage)
    {
        if (isDead) return; 

        currentHealth -= damage;

        if (!isColorRed)
        {
            StartCoroutine(DamageColorEffect());
        }


        HealthBarupdate();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DamageColorEffect()
    {
        isColorRed = true;
        sp.color = Color.red;

        yield return new WaitForSeconds(0.3f);  

        sp.color = Color.white;
        isColorRed = false;
    }
    private void Die()
    {
        isDead = true;

        agent.isStopped = true;


        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        
        HealthBar.gameObject.SetActive(false);

       
        Destroy(gameObject);
    }



    void HealthBarupdate()
    {
        float avg = Mathf.Clamp01(currentHealth / maxHealth);

        HealthBar.transform.localScale = new Vector3(avg, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.DisableRegen();      
            playerHealth.TakeDamage(2);
            animator.SetTrigger("IsCheer");
            Destroy(gameObject, 2f);
        }
    }

}

