using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image HealthBar;
    private float maxHealth = 10;
    private float currenthealth;
    [SerializeField] private float regenRate = 1f;
    [SerializeField] private float regenDelay = 3f; 
    private float lastDamageTime;
    [SerializeField] private Animator HealthColor›mprove;

    private bool canRegen = true;
    void Start()
    {
        currenthealth = maxHealth;
        lastDamageTime = Time.time;
        HealthColor›mprove.enabled = false;
    }

    private void Update()
    {
        HealthImpro();
    }

    public void TakeDamage(int damage)
    {
        currenthealth -= damage;
        HealthBarupdate();
        lastDamageTime = Time.time; 

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
            currenthealth = Mathf.Min(currenthealth, maxHealth);
            HealthColor›mprove.enabled = true;
            HealthColor›mprove.Play("CharacterHealth›mprove");
            HealthBarupdate();

            if (currenthealth == maxHealth)
            {
                HealthColor›mprove.StopPlayback();
                HealthColor›mprove.enabled = false;
                HealthBar.color = Color.red;
            }
        }
    }

    public void DisableRegen()
    {
        canRegen = false;
    }

}
