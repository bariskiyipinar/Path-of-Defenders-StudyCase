using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    private float maxHealth = 10;
    private float currenthealth;
    [SerializeField] private float regenRate = 1f;
    [SerializeField] private float regenDelay = 3f; 
    private float lastDamageTime;
    [SerializeField] private Animator HealthColorİmprove;
    [SerializeField] private Animator CharacterHealthİmage;

    [SerializeField] private ParticleSystem HealthEffect;

    private bool canRegen = true;
    void Start()
    {
        currenthealth = maxHealth;
        lastDamageTime = Time.time;
        HealthColorİmprove.enabled = false;

        CharacterHealthİmage.enabled = false;
    }

    private void Update()
    {
        HealthImpro();
    }

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
        HealthBarupdate();
        lastDamageTime = Time.time;

        CharacterHealthİmage.enabled = true;
        CharacterHealthİmage.Play("HealthCaracterİmage");
        CharacterHealthİmage.SetBool("IsImp", false);
        if (currenthealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void HealthBarupdate()
    {
        float avg = Mathf.Clamp01(currenthealth / maxHealth);
        HealthBar.transform.localScale = new Vector3(avg, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }

    public void HealthImpro()
    {
        if (!canRegen) return;

        if (currenthealth < maxHealth && Time.time - lastDamageTime >= regenDelay)
        {
            currenthealth += regenRate * Time.deltaTime;

            if (!HealthEffect.isPlaying)
            {
                HealthEffect.Play();
            }

            currenthealth = Mathf.Min(currenthealth, maxHealth);
            HealthColorİmprove.enabled = true;
            HealthColorİmprove.Play("CharacterHealthİmprove");
            CharacterHealthİmage.SetBool("IsImp", true);

            HealthBarupdate();

            if (currenthealth == maxHealth)
            {
                HealthColorİmprove.StopPlayback();
                HealthColorİmprove.enabled = false;
                HealthBar.color = Color.red;

                if (HealthEffect.isPlaying)
                {
                    HealthEffect.Stop();
                }

                CharacterHealthİmage.SetBool("IsImp", true);
            }
        }
        else
        {
            if (HealthEffect.isPlaying)
            {
                HealthEffect.Stop();
            }

       
        }
    }


    public void DisableRegen()
    {
        canRegen = false;
    }

}
